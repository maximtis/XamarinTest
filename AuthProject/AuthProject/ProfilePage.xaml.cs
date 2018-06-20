using AuthProject.Services.Auth.Interfaces;
using AuthProject.Modules.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuthProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage(IAuthResult<LoginResultModel> result)
		{
			InitializeComponent();
            Token.Text = result.GetData().TokenData.AccessToken;
            OrgId.Text = "Organization ID: "+ result.GetData().UserData.OrganizationId;
        }
	}
}