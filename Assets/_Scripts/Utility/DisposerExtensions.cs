using System;

namespace _Scripts.Utility
{
    public static class DisposerExtensions
    {
        public static void AddTo(this IDisposable disposable, IDisposer disposer)
        {
            disposer.Add(disposable);
        }
    }
}