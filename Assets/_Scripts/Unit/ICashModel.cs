using UniRx;

namespace _Scripts.Unit
{
    public interface ICashModel
    {
        IReadOnlyReactiveProperty<int> CurrentCash { get; }
        void Buy(int cost);
    }
}