using System.Collections.Generic;
using UnityEngine;
using _Scripts.Unit;

namespace _Scripts.Config
{
    public interface IShopConfig
    {
        int ShopEntryAmount { get; }
        IDictionary<int, int> AllShopUnits { get; }
        int GetCost(int id);
        UnitPreviewType GetPreviewType(int id);
        RenderTexture GetPreviewTexture(int id);
    }
}