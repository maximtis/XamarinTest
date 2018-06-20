using AuthProject.Common.ToastAlert.Interfaces;
using AuthProject.Common.ValidationHelpers;
using AuthProject.Modules.Auth.Models;
using AuthProject.Services.Auth;
using AuthProject.Services.Auth.Interfaces;
using AuthProject.Services.Auth.Models;
using AuthProject.Services.Navigation;
using AuthProject.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ReactiveUI.XamForms;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using AuthProject.Common;

namespace AuthProject.Modules.Auth.ViewModels
{
    public class AuthPageViewModel: ContentPageBase<AuthPageViewModel>
    {
        INavigation navigationContext;
        IAuthService authService;
        IAccountStorageService accountService;

        [Reactive]
        public ValidatableObject<string> Email { get; set; }
        [Reactive]
        public ValidatableObject<string> Password { get;set; }
        [Reactive]
        public ReactiveCommand<Unit, bool> LoginAsyncCommand { get; set; }

        public INavigation NavigationContext { get => navigationContext; set => navigationContext = value; }

        bool canDownload = true;

        public AuthPageViewModel()
        {
            authService = new AuthService();
            accountService = DependencyService.Get<IAccountStorageService>();
            AddValidations();

            Email.Value = "maxim.tis96@gmail.com";
            Password.Value = "@Qwerty123456";

        }
        private void AddValidations()
        {
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

            Email.Validations.Add(new IsNotNullOrEmptyRule<string>
                { ValidationMessage = "A username is required." });

            Email.Validations.Add(new EmailRule<string>
                { ValidationMessage = "Email has incorrect format." });

            Password.Validations.Add(new IsNotNullOrEmptyRule<string>
                { ValidationMessage = "A password is required." });

            //Password.Validations.Add(new PasswordRule<string>
            //    { ValidationMessage = "A password must be at least 8 contains numbers and letters." });
        }

        bool ValidateInputAsync()
        {
            return Email.Validate() && Password.Validate();
        }

        async Task LoginAsync()
        {
            if (!ValidateInputAsync())
                return;

            IAuthResult<LoginResultModel> result = 
                await authService.LoginAsync(Email.Value, Password.Value);
            
            if (!result.IsSuccess)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DependencyService.Get<IToastAlert>().LongAlert(result.Errors.ElementAt(0));
                });
                return;
            }
            try
            {
                IAccountModel account = new AccountModel()
                {
                    Email = Email.Value,
                    Password = Password.Value,
                    Token = result.GetData().TokenData.AccessToken
                };
                await accountService.AddAccount(account);
                await NavigationService.NavigateToAsync(new ProfilePage(result));
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DependencyService.Get<IToastAlert>().LongAlert(ex.Message);
                });
                return;
            }
            
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
