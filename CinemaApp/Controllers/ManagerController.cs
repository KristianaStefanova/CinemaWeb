using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class ManagerController : BaseController
    {
        public IActionResult Index()
        {
            return this.Ok("I am manager!!");
        }
    }
}
