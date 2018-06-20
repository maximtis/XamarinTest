using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using AuthProject.Services.Auth.Interfaces;
using Xamarin.Auth;
using AuthProject.Services.Auth.Models;
using System.Threading.Tasks;
using AuthProject.iOS.Services.Auth;

[assembly: Dependency(typeof(AccountStorageService))]
namespace AuthProject.iOS.Services.Auth
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
            await AccountStore.Create().SaveAsync(newAccount, App.AppName);
        }

        public async Task DeleteAccount()
        {
            if (!await IsAccountExists())
                return;
            AccountStore accountStore = AccountStore.Create();
            var accountsSearch = await accountStore
                .FindAccountsForServiceAsync(App.AppName);
            var oldAccount = accountsSearch.FirstOrDefault();
            await accountStore.DeleteAsync(oldAccount, App.AppName);
        }

        public async Task<IAccountModel> GetAccount()
        {
            if (string.IsNullOrWhiteSpace(App.AppName))
                throw new NullReferenceException("'ApplicationName' has no value!");

            var accountsSearch = await AccountStore.Create()
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
            var accountsSearch = await AccountStore.Create()
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