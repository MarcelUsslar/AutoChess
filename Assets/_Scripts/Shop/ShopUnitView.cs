﻿using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Shop
{
    public class ShopUnitView : MonoBehaviour, IShopUnitView
    {
        [SerializeField] private Text _costText;
        [SerializeField] private RawImage _previewImage;
        [SerializeField] private Button _purchaseButton;

        public bool Purchasable
        {
            set { _purchaseButton.interactable = value; }
        }

        public int Cost
        {
            set { _costText.text = string.Format("{0} Cash", value); }
        }

        public RenderTexture Preview
        {
            set { _previewImage.texture = value; }
        }

        public Button BuyButton
        {
            get { return _purchaseButton; }
        }
    }
}