using AuthProject.Services.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Services.Auth.Models
{
    public class AccountModel : IAccountModel
    {
        private string email;
        private string password;
        private string token;
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Token { get => token; set => token = value; }
    }
}
