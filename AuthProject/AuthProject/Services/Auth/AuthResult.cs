using AuthProject.Services.Auth.Interfaces;
using AuthProject.Modules.Auth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Services.Auth
{
    public class AuthResult:IAuthResult<LoginResultModel>
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        LoginResultModel resultData;
        public AuthResult(LoginResultModel data,bool status, IEnumerable<string> errors)
        {
            resultData = data;
            IsSuccess = status;
            Errors = errors;
        }

        public LoginResultModel GetData()
        {
            return resultData;
        }
    }
}
