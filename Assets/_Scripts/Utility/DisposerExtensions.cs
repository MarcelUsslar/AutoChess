using System;
using UniRx;

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

        public static IDisposable SubscribeBlind<T>(this IObservable<T> source, Action action)
        {
            return source.Subscribe(_ => action());
        }

        public static IObservable<bool> IfTrue(this IObservable<bool> source)
        {
            return source.Where(boolean => boolean);
        }
        public static IObservable<bool> IfFalse(this IObservable<bool> source)
        {
            return source.Where(boolean => !boolean);
        }
    }

    public static class DisposerExtensions
    {
        public static T AddToDisposer<T>(this T disposable, IDisposer disposer) where T : IDisposable
        {
            disposer.Add(disposable);
            return disposable;
        }
    }
}