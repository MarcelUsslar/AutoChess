using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Scripts.PlayAreas
{
    public interface IFieldFactory : IFactory<Transform, Vector2Int, Dictionary<int, Dictionary<int, IFieldView>>>
    { }
}