using UnityEngine;

namespace _Scripts.Config
{
    public interface IBoardConfig
    {
        Vector2Int BoardSize { get; }
        Vector2Int UnitInventorySize { get; }
    }
}