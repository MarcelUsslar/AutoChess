using System;

namespace _Scripts.Utility
{
    public interface IDisposer
    {
        void Add(IDisposable disposable);
    }
}