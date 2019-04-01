using System;
using UniRx;

namespace _Scripts.Utility
{
    public class Disposer : IDisposable, IDisposer
    {
        private readonly CompositeDisposable _container;

        public static Disposer Create()
        {
            return new Disposer();
        }

        private Disposer()
        {
            _container = new CompositeDisposable();
        }

        public void Add(IDisposable disposable)
        {
            _container.Add(disposable);
        }
        
        public void Dispose()
        {
            if (_container.IsDisposed)
                return;

            _container.Dispose();
        }
    }
}
