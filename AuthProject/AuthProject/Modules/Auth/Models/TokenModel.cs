using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Modules.Auth.Models
{
    public class TokenModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}