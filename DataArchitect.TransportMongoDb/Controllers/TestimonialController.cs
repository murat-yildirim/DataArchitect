using DataArchitect.TransportMongoDb.Dtos.TestimonialDtos;
using DataArchitect.TransportMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DataArchitect.TransportMongoDb.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _TestimonialService.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _TestimonialService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _TestimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _TestimonialService.GetTestimonialByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _TestimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
    }
}
