using Microsoft.AspNetCore.Mvc;

namespace electroMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
