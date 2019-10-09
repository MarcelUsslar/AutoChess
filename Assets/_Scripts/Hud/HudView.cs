using UnityEngine;
using UnityEngine.UI;
using _Scripts.Utility;

namespace _Scripts.Hud
{
    public class HudView : PanelView, IHudView
    {
        [SerializeField] private Button _shopButton;

        public Button ShopButton
        {
            get { return _shopButton; }
        }
    }
}
