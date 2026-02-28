using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
