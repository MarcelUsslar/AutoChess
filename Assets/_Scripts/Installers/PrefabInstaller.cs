using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using _Scripts.Hud;
using _Scripts.PlayAreas;
using _Scripts.Shop;
using _Scripts.Unit;

namespace _Scripts.Installers
{
    [CreateAssetMenu(fileName = "PrefabInstaller", menuName = "Installers/PrefabInstaller")]
    public class PrefabInstaller : ScriptableObjectInstaller<PrefabInstaller>
    {
        [SerializeField] private BenchView _benchView;
        [SerializeField] private BoardView _boardView;
        [SerializeField] private FieldView _fieldView;
        [SerializeField] private HudView _hudView;
        [SerializeField] private PreparationUnitView _preparationUnitView;
        [SerializeField] private ShopUnitView _shopUnitView;
        [SerializeField] private ShopPanelView _shopPanelView;

        public override void InstallBindings()
        {
            BindSingletonView(_benchView, true);
            BindSingletonView(_boardView, true);
            BindSingletonView(_hudView, true);
            BindViewFactory(_fieldView);
            BindViewFactory(_preparationUnitView);
            BindViewFactory(_shopUnitView);
            BindSingletonView(_shopPanelView);
        }

        #region ViewFactories
        private void BindViewFactory<TView>(TView view) where TView : MonoBehaviour
        {
            Container.Bind<IViewFactory<TView>>().To<ViewFactory<TView>>().AsSingle().WithArguments(view);
        }
        
        private void BindViewFactoryByType<TParam, TView>(IDictionary<TParam, TView> delayedAssets)
            where TView : MonoBehaviour
        {
            Container.Bind<IViewFactory<TParam, TView>>().To<ViewFactory<TParam, TView>>().AsSingle()
                .WithArguments(delayedAssets);
        }
        
        private void BindViewFactory<TView>(TView view, object id) where TView : MonoBehaviour
        {
            Container.Bind<IViewFactory<TView>>().WithId(id).To<ViewFactory<TView>>().AsSingle()
                .WithConcreteId(id).WithArguments(view);
        }
        
        private void BindSingletonView<TView>(TView view, bool activeByDefault = false) where TView : MonoBehaviour
        {
            view.gameObject.SetActive(activeByDefault);
            Container.BindInterfacesAndSelfTo<TView>().FromComponentInNewPrefab(view.gameObject)
                .UnderTransformGroup("Singleton Views").AsSingle();
        }

        private class ViewFactory<TView> : IViewFactory<TView> where TView : MonoBehaviour
        {
            private readonly DiContainer _container;
            private readonly TView _view;

            protected ViewFactory(DiContainer container, TView view)
            {
                _container = container;
                _view = view;
            }

            public TView Instantiate()
            {
                return _container.InstantiatePrefabForComponent<TView>(_view);
            }

            public virtual TView Instantiate(bool visible)
            {
                var view = Instantiate();
                view.gameObject.SetActive(visible);
                return view;
            }

            public TView Instantiate(Transform parent)
            {
                return _container.InstantiatePrefabForComponent<TView>(_view, parent);
            }

            public virtual TView Instantiate(Transform parent, bool visible)
            {
                var view = Instantiate(parent);
                view.gameObject.SetActive(visible);
                return view;
            }

            public TView InstantiateInWorldSpace(Transform parent)
            {
                var view = Instantiate();
                view.transform.SetParent(parent, true);
                return view;
            }

            public TView InstantiateInWorldSpace(Transform parent, bool visible)
            {
                var view = Instantiate(visible);
                view.transform.SetParent(parent, true);
                return view;
            }

            public Func<TView> InstantiateLazy()
            {
                return Instantiate;
            }

            public Func<TView> InstantiateLazy(bool visible)
            {
                return () => Instantiate(visible);
            }

            public Func<TView> InstantiateLazy(Transform parent)
            {
                return () => Instantiate(parent);
            }

            public Func<TView> InstantiateLazy(Transform parent, bool visible)
            {
                return () => Instantiate(parent, visible);
            }

            public Func<TView> InstantiateInWorldSpaceLazy(Transform parent)
            {
                return () => InstantiateInWorldSpace(parent);
            }

            public Func<TView> InstantiateInWorldSpaceLazy(Transform parent, bool visible)
            {
                return () => InstantiateInWorldSpace(parent, visible);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        
        private class ViewFactory<TParam, TView> : IViewFactory<TParam, TView> where TView : MonoBehaviour
        {
            private readonly DiContainer _container;
            private readonly IDictionary<TParam, TView> _delayedAssets;

            protected ViewFactory(DiContainer container, IDictionary<TParam, TView> delayedAssets)
            {
                _container = container;
                _delayedAssets = delayedAssets;
            }

            public TView Instantiate(TParam param)
            {
                return _container.InstantiatePrefabForComponent<TView>(_delayedAssets[param]);
            }

            public virtual TView Instantiate(TParam param, bool visible)
            {
                var view = Instantiate(param);
                view.gameObject.SetActive(visible);
                return view;
            }

            public TView Instantiate(TParam param, Transform parent)
            {
                return _container.InstantiatePrefabForComponent<TView>(_delayedAssets[param], parent);
            }

            public virtual TView Instantiate(TParam param, Transform parent, bool visible)
            {
                var view = Instantiate(param, parent);
                view.gameObject.SetActive(visible);
                return view;
            }

            public TView InstantiateInWorldSpace(TParam param, Transform parent)
            {
                var view = Instantiate(param);
                view.transform.SetParent(parent, true);
                return view;
            }

            public TView InstantiateInWorldSpace(TParam param, Transform parent, bool visible)
            {
                var view = Instantiate(param, visible);
                view.transform.SetParent(parent, true);
                return view;
            }

            public Func<TView> InstantiateLazy(TParam param)
            {
                return () => Instantiate(param);
            }

            public Func<TView> InstantiateLazy(TParam param, bool visible)
            {
                return () => Instantiate(param, visible);
            }

            public Func<TView> InstantiateLazy(TParam param, Transform parent)
            {
                return () => Instantiate(param, parent);
            }

            public Func<TView> InstantiateLazy(TParam param, Transform parent, bool visible)
            {
                return () => Instantiate(param, parent, visible);
            }

            public Func<TView> InstantiateInWorldSpaceLazy(TParam param, Transform parent)
            {
                return () => InstantiateInWorldSpace(param, parent);
            }

            public Func<TView> InstantiateInWorldSpaceLazy(TParam param, Transform parent, bool visible)
            {
                return () => InstantiateInWorldSpace(param, parent, visible);
            }
        }
        #endregion
    }
}