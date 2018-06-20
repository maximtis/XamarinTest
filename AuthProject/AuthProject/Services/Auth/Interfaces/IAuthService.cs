using AuthProject.Modules.Auth.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthProject.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<IAuthResult<LoginResultModel>> LoginAsync(string email, string password); 
    }
}
