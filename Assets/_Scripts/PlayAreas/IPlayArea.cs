using UnityEngine;

namespace _Scripts.PlayAreas
{
    public interface IPlayArea
    {
        Vector2Int GetFirstFreePosition();
    }
}