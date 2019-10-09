using UnityEngine;

namespace _Scripts.PlayAreas
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField] private Transform _boardParent;

        public Transform BoardParent
        {
            get { return _boardParent; }
        }
    }
}