using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.ViewComponents.AdminComponents
{
    public class _AdminLayoutSidebarComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
