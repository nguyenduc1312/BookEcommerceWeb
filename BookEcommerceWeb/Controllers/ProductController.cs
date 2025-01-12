using Microsoft.AspNetCore.Mvc;

namespace BookEcommerceWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
