using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Modules.Auth.Models
{
    public class UserDataModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("organizationId")]
        public int OrganizationId { get; set; }
        [JsonProperty("officeId")]
        public int OfficeId { get; set; }
        [JsonProperty("dateFormat")]
        public string DateFormat { get; set; }
        [JsonProperty("dateTimeFormat")]
        public string DateTimeFormat { get; set; }
        [JsonProperty("idle")]
        public int Idle { get; set; }
        [JsonProperty("timeout")]
        public int Timeout { get; set; }
        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("showNewUserPopup")]
        public bool ShowNewUserPopup { get; set; }
        [JsonProperty("signatureConfig")]
        public SignatureConfig SignatureConfig { get; set; }
        [JsonProperty("organizationType")]
        public int OrganizationType { get; set; }
    }
    public class SignatureConfig
    {
        public int Id { get; set; }
        public int DefaultSignatureDevice { get; set; }
        public bool TopazSignatureDeviceSelected { get; set; }
        public bool TouchScreenSignatureDeviceSelected { get; set; }
        public bool NoSignatureDeviceSelected { get; set; }
    }

}
