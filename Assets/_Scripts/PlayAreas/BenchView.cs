using UnityEngine;

namespace _Scripts.PlayAreas
{
    public class BenchView : MonoBehaviour
    {
        [SerializeField] private Transform _benchParent;

        public Transform BenchParent
        {
            get { return _benchParent; }
        }
    }
}