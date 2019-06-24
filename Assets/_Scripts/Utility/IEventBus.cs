using UniRx;

namespace _Scripts.Utility
{
    public interface IEventBus
    {
        IObservable<T> OnEvent<T>();
        void Publish<T>(T message);
    }
}