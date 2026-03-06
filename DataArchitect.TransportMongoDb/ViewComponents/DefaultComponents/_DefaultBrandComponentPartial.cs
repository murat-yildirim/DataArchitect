using DataArchitect.TransportMongoDb.Services.BrandServices;
using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        private readonly IBrandService _BrandService;

        public _DefaultBrandComponentPartial(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _BrandService.GetAllBrandAsync();
            var activeValues = values.Where(x => x.IssStatus == true).ToList();
            return View(activeValues);
        }

    }
}
