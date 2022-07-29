using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backrooms.Data
{
    public class UserDataService
    {
        public Task<DiscordToken> GetToken(DiscordCode respond)
        {
            var client = new HttpClient();
            var requestContent = new FormUrlEncodedContent(new [] {
                new KeyValuePair<string, string>("client_id", "1000188282841350144"),
                new KeyValuePair<string, string>("client_secret", "QYAIxINojHCRDpFpKWo1ldZJaWueUkjv"),
                new KeyValuePair<string, string>("code", respond.code),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("redirect_uri", "http://localhost:5000/callback"),
                new KeyValuePair<string, string>("scope", "identify"),
            });
            var response = client.PostAsync("https://discord.com/api/oauth2/token", requestContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return Task.FromResult(JsonSerializer.Deserialize<DiscordToken>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));
        }
    }
}


// app.get('/', async ({ query }, response) => {
// 	const { code } = query;

// 	if (code) {
// 		try {
// 			const tokenResponseData = await request('https://discord.com/api/oauth2/token', {
// 				method: 'POST',
// 				body: new URLSearchParams({
// 					client_id: clientId,
// 					client_secret: clientSecret,
// 					code,
// 					grant_type: 'authorization_code',
// 					redirect_uri: `http://localhost:${port}`,
// 					scope: 'identify',
// 				}),
// 				headers: {
// 					'Content-Type': 'application/x-www-form-urlencoded',
// 				},
// 			});

// 			const oauthData = await getJSONResponse(tokenResponseData.body);
// 			console.log(oauthData);
// 		} catch (error) {
// 			// NOTE: An unauthorized token will not throw an error
// 			// tokenResponseData.statusCode will be 401
// 			console.error(error);
// 		}
// 	}