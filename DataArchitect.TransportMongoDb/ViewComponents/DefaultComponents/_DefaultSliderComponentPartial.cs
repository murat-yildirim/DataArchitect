using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
