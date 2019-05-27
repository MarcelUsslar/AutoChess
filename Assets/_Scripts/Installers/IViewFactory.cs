using System;
using UnityEngine;

namespace _Scripts.Installers
{
    public interface IViewFactory<TView> where TView : MonoBehaviour
    {
        TView Instantiate();
        TView Instantiate(bool visible);
        TView Instantiate(Transform parent);
        TView Instantiate(Transform parent, bool visible);
        TView InstantiateInWorldSpace(Transform parent);
        TView InstantiateInWorldSpace(Transform parent, bool visible);
        Func<TView> InstantiateLazy();
        Func<TView> InstantiateLazy(bool visible);
        Func<TView> InstantiateLazy(Transform parent);
        Func<TView> InstantiateLazy(Transform parent, bool visible);
        Func<TView> InstantiateInWorldSpaceLazy(Transform parent);
        Func<TView> InstantiateInWorldSpaceLazy(Transform parent, bool visible);
    }

    public interface IViewFactory<TParam, TView> where TView : MonoBehaviour
    {
        TView Instantiate(TParam param);
        TView Instantiate(TParam param, bool visible);
        TView Instantiate(TParam param, Transform parent);
        TView Instantiate(TParam param, Transform parent, bool visible);
        TView InstantiateInWorldSpace(TParam param, Transform parent);
        TView InstantiateInWorldSpace(TParam param, Transform parent, bool visible);
        Func<TView> InstantiateLazy(TParam param);
        Func<TView> InstantiateLazy(TParam param, bool visible);
        Func<TView> InstantiateLazy(TParam param, Transform parent);
        Func<TView> InstantiateLazy(TParam param, Transform parent, bool visible);
        Func<TView> InstantiateInWorldSpaceLazy(TParam param, Transform parent);
        Func<TView> InstantiateInWorldSpaceLazy(TParam param, Transform parent, bool visible);
    }
}