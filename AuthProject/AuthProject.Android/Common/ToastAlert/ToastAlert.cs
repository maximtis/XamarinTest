using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AuthProject.Common.ToastAlert.Interfaces;
using AuthProject.Droid.Common.ToastAlert;

[assembly: Dependency(typeof(ToastAlert))]
namespace AuthProject.Droid.Common.ToastAlert
{
    public class ToastAlert : IToastAlert
    {
        public void LongAlert(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
            });
        }

        public void ShortAlert(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
            });
        }
    }
}