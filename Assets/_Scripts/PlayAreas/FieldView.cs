using UnityEngine;

namespace _Scripts.PlayAreas
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private Transform _unitParent;

        public Vector3 Position
        {
            set { gameObject.transform.localPosition = value; }
        }

        public Transform UnitParent
        {
            get { return _unitParent; }
        }
    }
}