using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace EntityFramework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController()
        {

        }

        //[AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("https://accounts.google.com/o/");

                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.UTF8.GetBytes("821333001423-poemjan0bgfso7iffvldoeapajcgagm2.apps.googleusercontent.com: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"))
                    );

                var result = await httpclient.PostAsync("oauth2/v2/auth", new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("client_id", "821333001423-poemjan0bgfso7iffvldoeapajcgagm2.apps.googleusercontent.com"),
                        new KeyValuePair<string, string>("scope", "openid"),
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("response_type", "code"),
                        new KeyValuePair<string, string>("redirect_uri", "https://localhost:44376/api/v1/callback"),
                        new KeyValuePair<string, string>("access_type", "offline"),
                    }
                    ));

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();
                }

                return null;

            }
        }


        //[AllowAnonymous]
        [HttpPost("callback")]
        public async Task<IActionResult> GoogleCallback(string returnUrl = null, string remoteError = null)
        {
            // Handle the callback logic here

            // Redirect the user to the desired page after successful authentication
            return Redirect(returnUrl ?? "/");
        }
    }
}
