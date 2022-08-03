using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
namespace Backrooms.Data
{
    public class UserDataService
    {
        public async Task<string> GetToken(string code){
             HttpClient client = new HttpClient();
             var values = new Dictionary<string, string>
                {
                    { "client_id", "1000188282841350144" },
                    { "client_secret", "QYAIxINojHCRDpFpKWo1ldZJaWueUkjv" },
                    { "code", code },
                    { "grant_type", "authorization_code" },
                    { "redirect_uri", "https://backrooms.azurewebsites.net/login-callback" },
                    { "scope", "identify" },
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://discord.com/api/oauth2/token", content);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
        }
        public async Task<string> GetData(DiscordToken token){
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization 
                         = new AuthenticationHeaderValue("Bearer", token.access_token);

                var response = await client.GetAsync($"https://discord.com/api/users/@me");

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
        }
    }
}