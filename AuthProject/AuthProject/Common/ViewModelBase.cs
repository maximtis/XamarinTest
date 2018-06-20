using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Threading;
using ReactiveUI;

namespace AuthProject.ViewModels
{
    public abstract class ViewModelBase<T> : ReactiveObject, IDisposable where T : ReactiveObject, IDisposable 
{
    // 2
    protected readonly Lazy<CompositeDisposable> ViewModelBindings = new Lazy<CompositeDisposable>(() => new CompositeDisposable());
    // 3
    public bool IsDisposed { get; private set; }
    // 4
    protected abstract void RegisterObservables();
    // 5
    protected ViewModelBase()
    {
        RegisterObservables();
    }
    // 6
    #region IDisposable implementation
    public void Dispose()
    {
        if (!IsDisposed)
        {
            IsDisposed = true;
            Dispose(true);
            GC.SuppressFinalize(true);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)

        if (ViewModelBindings != null)
        {
            ViewModelBindings.Value.Dispose();
        }
    }

    #endregion
} 
}
