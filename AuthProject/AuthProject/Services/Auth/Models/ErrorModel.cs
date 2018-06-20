using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Services.Auth.Models
{
    class ErrorModel
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
