using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
