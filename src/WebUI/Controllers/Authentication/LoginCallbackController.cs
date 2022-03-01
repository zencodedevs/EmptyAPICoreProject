using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ZenAchitecture.WebUIAdmin.Controllers.Authentication
{
    [Route("authentication/login-callback")]
    public class LoginCallbackController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginCallbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ActionResult Index(
                [FromQuery(Name = "code")] string code,
                [FromQuery(Name = "scope")] string scope,
                [FromQuery(Name = "state")] string state,
                [FromQuery(Name = "session_state")] string session_state
            )
        {

            var redirectUrl =
                string.Format(
                    "{0}/authentication/login-callback?code={1}&scope={2}&state={3}&session_state={4}"
                    , _configuration.GetSection("EndPoints")["WebsiteUrl"]
                    , code
                    , scope
                    , state
                    , session_state);


            ViewBag.RedirectUrl = redirectUrl;

            return View();
        }
    }


}
