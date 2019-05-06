using UnityEngine;

namespace _Scripts.Board
{
    public interface IBoardConfig
    {
        Vector2Int BoardSize { get; }
        Vector2Int UnitInventorySize { get; }
    }
}