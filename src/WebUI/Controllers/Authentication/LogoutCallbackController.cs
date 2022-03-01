using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ZenAchitecture.WebUIAdmin.Controllers.Authentication
{
    [Route("authentication/logout-callback")]
    public class LogoutCallbackController : Controller
    {
        private readonly IConfiguration _configuration;

        public LogoutCallbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Index(
                [FromQuery(Name = "state")] string state
            )
        {
            var redirectUrl =
                string.Format(
                        "{0}/authentication/logout-callback?state={1}"
                        , _configuration.GetSection("EndPoints")["WebsiteUrl"]
                        , state
                     );

            ViewBag.RedirectUrl = redirectUrl;

            return View();
        }
    }
}
