using UnityEngine;
using Zenject;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public interface IShopFactory : IFactory<int, Transform, IShopUnitModel>
    { }
}