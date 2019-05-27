using UnityEngine;
using Zenject;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Factories
{
    public interface IShopFactory : IFactory<int, Transform, IDisposer, IShopUnitModel>
    { }
}