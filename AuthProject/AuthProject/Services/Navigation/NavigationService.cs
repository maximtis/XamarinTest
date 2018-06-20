using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuthProject.Services.Navigation
{
    class NavigationService
    {
        public static async Task NavigateToAsync(Page page)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(page);
            });
        }
    }
}
