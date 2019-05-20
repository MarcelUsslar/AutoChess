using UnityEngine;

namespace _Scripts.Config
{
    [CreateAssetMenu(fileName = "BoardConfig", menuName = "Configs/Board Config")]
    public class BoardConfig : ScriptableObject, IBoardConfig
    {
        [SerializeField] private Vector2Int _boardSize;
        [SerializeField] private Vector2Int _unitInventorySize;


        public Vector2Int BoardSize
        {
            get { return _boardSize; }
        }
        public Vector2Int UnitInventorySize
        {
            get { return _unitInventorySize; }
        }
    }
}