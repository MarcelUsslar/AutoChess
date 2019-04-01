using System;
using UniRx;

namespace _Scripts.Services
{
    public interface ITickService
    {
        IReadOnlyReactiveProperty<int> CurrentTick { get; }
        IReadOnlyReactiveProperty<int> SubTick { get; }

        void ForwardToNextTick();
        void EndCharacterAction();
    }
}