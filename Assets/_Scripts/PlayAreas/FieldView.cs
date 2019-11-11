using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.PlayAreas
{
    public class FieldView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IFieldView
    {
        [SerializeField] private Transform _unitParent;
        [SerializeField] private MeshRenderer _fieldRenderer;

        private Subject<UniRx.Unit> _onPointerEnterAsObservable;
        private Subject<UniRx.Unit> _onPointerExitAsObservable;
        private Subject<UniRx.Unit> _onPointerClickAsObservable;

        public IObservable<UniRx.Unit> OnPointerEnterAsObservable
        {
            get { return _onPointerEnterAsObservable ?? (_onPointerEnterAsObservable = new Subject<UniRx.Unit>()); }
        }
        public IObservable<UniRx.Unit> OnPointerExitAsObservable
        {
            get { return _onPointerExitAsObservable ?? (_onPointerExitAsObservable = new Subject<UniRx.Unit>()); }
        }
        public IObservable<UniRx.Unit> OnPointerClickAsObservable
        {
            get { return _onPointerClickAsObservable ?? (_onPointerClickAsObservable = new Subject<UniRx.Unit>()); }
        }

        public Vector3 Position
        {
            set { gameObject.transform.localPosition = value; }
        }

        public Transform UnitParent
        {
            get { return _unitParent; }
        }

        public Material FieldMaterial
        {
            set { _fieldRenderer.material = value; }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_onPointerEnterAsObservable != null)
            {
                _onPointerEnterAsObservable.OnNext(UniRx.Unit.Default);
            }
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if (_onPointerExitAsObservable != null)
            {
                _onPointerExitAsObservable.OnNext(UniRx.Unit.Default);
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_onPointerClickAsObservable != null)
            {
                _onPointerClickAsObservable.OnNext(UniRx.Unit.Default);
            }
        }
    }
}