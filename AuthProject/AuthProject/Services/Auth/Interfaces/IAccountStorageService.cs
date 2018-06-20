using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthProject.Services.Auth.Interfaces
{
    public interface IAccountStorageService
    {
        Task AddAccount(IAccountModel account);
        Task<IAccountModel> GetAccount();
        Task<bool> IsAccountExists();
        Task DeleteAccount();
        Task UpdateAccount(IAccountModel account);
    }
}
