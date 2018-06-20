using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Modules.Auth.Models
{
    public class LoginResultModel
    {

        public TokenModel TokenData { get; set; }
        public UserDataModel UserData { get; set; }
        
    }
}
