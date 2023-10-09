using Microsoft.AspNetCore.Mvc;

namespace Handicraft_proj.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult AllProducts()
        {
            return View();
        }
    }
}
