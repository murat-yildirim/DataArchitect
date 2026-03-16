using DataArchitect.TransportMongoDb.Dtos.TestimonialDtos;

namespace DataArchitect.TransportMongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
        Task DeleteTestimonialAsync(string id);
    }
}
