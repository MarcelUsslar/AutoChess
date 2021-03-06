﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.Config
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/Shop Config")]
    public class ShopConfig : ScriptableObject, IShopConfig
    {
#pragma warning disable 0649
        [Serializable]
        private class ShopEntryMapping
        {
            public int UnitId;
            public int UnitWeight;
            public int UnitCost;
        }
#pragma warning restore 0649

        [SerializeField] private int _shopEntryAmount;
        [SerializeField] private List<ShopEntryMapping> _shopEntries; 

        public int ShopEntryAmount
        {
            get { return _shopEntryAmount; }
        }

        public IDictionary<int, int> AllShopUnits
        {
            get { return _shopEntries.ToDictionary(mapping => mapping.UnitId, mapping => mapping.UnitWeight); }
        }

        public int GetCost(int id)
        {
            return _shopEntries.First(mapping => mapping.UnitId == id).UnitCost;
        }
    }
}