using AuthProject.Modules.Auth.ViewModels;
using AuthProject.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ReactiveUI;
using AuthProject.Common;

namespace AuthProject.Modules.Auth
{
	public partial class AuthPage: ContentPageBase<AuthPageViewModel>
    {
        public string MyProperty { get; set; }
        public AuthPage():base()
		{
			InitializeComponent();
        }

        protected override void SetupUserInterface()
        {
            //void
        }

        protected override void BindControls()
        {
            //void
        }
    }
}
