using DataArchitect.TransportMongoDb.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IAboutService _AboutService;

        public _DefaultAboutComponentPartial(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _AboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
