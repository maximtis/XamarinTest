using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

using AuthProject.Common.ToastAlert.Interfaces;
using AuthProject.Droid.Common.ToastAlert;
using Windows.UI.Popups;
using System.Threading.Tasks;

[assembly: Dependency(typeof(ToastAlert))]
namespace AuthProject.Droid.Common.ToastAlert
{
    public class ToastAlert : IToastAlert
    {
        public void LongAlert(string message)
        {
            var dialog = new MessageDialog(message);
            dialog.ShowAsync();
        }

        public void ShortAlert(string message)
        {
            var dialog = new MessageDialog(message);
            dialog.ShowAsync();
        }
    }
}