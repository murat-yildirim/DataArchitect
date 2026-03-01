using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultMobileMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
