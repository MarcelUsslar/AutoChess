using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using _Scripts.Config;

namespace _Scripts.Services
{
    public class RandomUnitGenerator : IRandomUnitGenerator
    {
        private readonly IDictionary<int, int> _allShopUnits;

        public RandomUnitGenerator(IShopConfig shopConfig)
        {
            _allShopUnits = shopConfig.AllShopUnits;
        }

        public int GetRandomUnitId()
        {
            var randomNumber = Random.Range(0, _allShopUnits.Values.Sum());
            foreach (var shopUnit in _allShopUnits)
            {
                randomNumber -= shopUnit.Value;
                if (randomNumber > 0)
                    continue;
                
                return shopUnit.Key;
            }
            
            return _allShopUnits.Last().Key;
        }
    }
}
