using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Services.Auth.Interfaces
{
    public interface IAccountModel
    {
        string Email { get; set; }
        string Password { get; set; }
        string Token { get; set; }
    }
}
