using AuthProject.Services.Auth.Interfaces;
using AuthProject.Modules.Auth.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AuthProject.Services.Auth.Models;

namespace AuthProject.Services.Auth
{
    class AuthService : IAuthService
    {
        public AuthService()
        {
            result = new LoginResultModel()
            {
                TokenData = null,
                UserData = null
            };
            Errors = new List<string>();
            isSuccess = true;
        }
        private LoginResultModel result;
        private bool isSuccess;
        IList<string> Errors;
        const string EndPoint = "http://192.168.2.176:55571";
       
        public async Task<TokenModel> GetToken(LoginModel data)
        {
            Uri uri = new Uri(EndPoint + "/Token");

            // grant_type: password
            // username: maxim.tis96 @gmail.com
            // password: "Qwerty12345

            var content = new StringContent($"grant_type=password&username={System.Net.WebUtility.HtmlEncode(data.Email)}&password={System.Net.WebUtility.HtmlEncode(data.Password)}",
            Encoding.UTF8,
            "application/x-www-form-urlencoded");
            //try
            //{
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = null;
                    client.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    response = await client.PostAsync(uri, content);

                    if(!response.IsSuccessStatusCode)
                    {
                        isSuccess = false;
                        await ExtractError(response);
                        return null;
                    }
                    var result = await response.Content.ReadAsStringAsync();
                    TokenModel token = JsonConvert.DeserializeObject<TokenModel>(result);

                    return token;
                }
            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //    return null;
            //}
            
        }

        public async Task<UserDataModel> GetUserData(TokenModel token)
        {
            if (token == null)
                return null;
            string uri = EndPoint + "/api/users/userData";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Add("Authorization", "Bearer " + token.AccessToken);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = null;
                response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    isSuccess = false;
                    await ExtractError(response);
                    return null;
                }
                var result = await response.Content.ReadAsStringAsync();
                UserDataModel userData = JsonConvert.DeserializeObject<UserDataModel>(result);
                return userData;
            }
        }

        public async Task<IAuthResult<LoginResultModel>> LoginAsync(string email, string password)
        {
            var LoginModel = new LoginModel()
            {
                Email = email,
                Password = password,
                GrantType = "password"
            };

            result.TokenData = await GetToken(LoginModel);
            result.UserData = await GetUserData(result.TokenData);
            return new AuthResult(result, isSuccess, Errors);
        }

        async Task ExtractError(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var serverError = JsonConvert.DeserializeObject<ErrorModel>(content);
            Errors.Add(serverError.ErrorDescription);
        }
    }
}
