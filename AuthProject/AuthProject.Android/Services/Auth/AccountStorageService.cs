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
using AuthProject.Droid.Services.Auth;
using AuthProject.Services.Auth.Interfaces;
using Xamarin.Auth;
using AuthProject.Services.Auth.Models;
using System.Threading.Tasks;

[assembly: Dependency(typeof(AccountStorageService))]
namespace AuthProject.Droid.Services.Auth
{
    public class AccountStorageService : IAccountStorageService
    {
        public async Task AddAccount(IAccountModel account)
        {
            if (string.IsNullOrWhiteSpace(account.Email) || string.IsNullOrWhiteSpace(account.Password))
                throw new NullReferenceException("'Email' or 'Password' from account data has no value!");

            Account newAccount = new Account(account.Email);
            newAccount.Properties.Add("Password", account.Password);
            newAccount.Properties.Add("Token", account.Token);
            await AccountStore.Create(Android.App.Application.Context).SaveAsync(newAccount, App.AppName);
        }

        public async Task DeleteAccount()
        {
            if (!await IsAccountExists())
                return;
            AccountStore accountStore = AccountStore.Create(Android.App.Application.Context);
            var accountsSearch = await accountStore
                .FindAccountsForServiceAsync(App.AppName);
            var oldAccount = accountsSearch.FirstOrDefault();
            await accountStore.DeleteAsync(oldAccount, App.AppName);
        }

        public async Task<IAccountModel> GetAccount()
        {
            if (string.IsNullOrWhiteSpace(App.AppName))
                throw new NullReferenceException("'ApplicationName' has no value!");

            var accountsSearch = await AccountStore.Create(Android.App.Application.Context)
                .FindAccountsForServiceAsync(App.AppName);
            var account = accountsSearch.FirstOrDefault();

            return (account != null) ?
                new AccountModel()
                {
                    Email = account.Username,
                    Password = account.Properties["Password"],
                    Token = account.Properties["Token"]
                } : null;
        }

        public async Task<bool> IsAccountExists()
        {
            var accountsSearch = await AccountStore.Create(Android.App.Application.Context)
                .FindAccountsForServiceAsync(App.AppName);
            return accountsSearch.Any();
        }

        public async Task UpdateAccount(IAccountModel newAccount)
        {
            if (!await IsAccountExists())
                throw new InvalidOperationException("You cannot update not existing account!");
            await DeleteAccount();
            await AddAccount(newAccount);
        }
    }
}