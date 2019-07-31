using Microsoft.AspNetCore.Antiforgery;
using TCC.Controllers;

namespace TCC.Web.Host.Controllers
{
    public class AntiForgeryController : TCCControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
