using UniRx;

namespace _Scripts.Utility
{
    public class UniRxEventBus : IEventBus
    {
        public IObservable<T> OnEvent<T>()
        {
            return MessageBroker.Default.Receive<T>();
        }

        public void Publish<T>(T message)
        {
            MessageBroker.Default.Publish(message);
        }
    }
}