using UnityEngine;

namespace _Scripts.Unit
{
    public class ShopPanelView : MonoBehaviour, IShopPanelView
    {
        [SerializeField] private Transform _unitParent;

        public Transform UnitParent => _unitParent;
    }
}