using Microsoft.AspNetCore.Mvc;

namespace BookEcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
