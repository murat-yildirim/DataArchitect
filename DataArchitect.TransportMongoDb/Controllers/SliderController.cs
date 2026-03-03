using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult SliderList()
        {
            return View();
        }
    }
}
