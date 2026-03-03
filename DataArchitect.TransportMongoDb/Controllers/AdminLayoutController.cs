using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
