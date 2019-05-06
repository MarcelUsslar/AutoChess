using System;

namespace _Scripts.Utility
{
    public static class ExtensionMethods
    {
        public static void Times(this int times, Action action)
        {
            for (var i = 0; i < times; i++)
            {
                action();
            }
        }
        public static void Times(this int times, Action<int> action)
        {
            for (var i = 0; i < times; i++)
            {
                action(i);
            }
        }
    }

    public static class DisposerExtensions
    {
        public static T AddTo<T>(this T disposable, IDisposer disposer) where T : IDisposable
        {
            disposer.Add(disposable);
            return disposable;
        }
    }
}