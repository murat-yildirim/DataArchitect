using DataArchitect.TransportMongoDb.Dtos.BrandDtos;

namespace DataArchitect.TransportMongoDb.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task<GetBrandByIdDto> GetBrandByIdAsync(string id);
        Task DeleteBrandAsync(string id);
    }
}
