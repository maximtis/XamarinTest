using AuthProject.Modules.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace AuthProject
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            try
            {
                MainPage = new NavigationPage((new AuthPage()));

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
			           
		}

        public static string AppName
        {
            get
            {
                return "SAFE Evidence";
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
