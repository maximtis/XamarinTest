using AuthProject.ViewModels;
using ReactiveUI.XamForms;
using System;
using System.Reactive.Disposables;
using Xamarin.Forms;

namespace AuthProject.Common
{
    public abstract class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel>
  where TViewModel : class
    {
        protected Lazy<CompositeDisposable> ControlBindings = new Lazy<CompositeDisposable>(() => new CompositeDisposable());
        protected abstract void SetupUserInterface();
        protected abstract void BindControls();

        protected ContentPageBase() : base()
        {
            SetupUserInterface();
            BindControls();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UnbindControls();
        }

        protected void UnbindControls()
        {
            if (ControlBindings == null) return;
            ControlBindings.Value.Clear();
        }
    }
}
