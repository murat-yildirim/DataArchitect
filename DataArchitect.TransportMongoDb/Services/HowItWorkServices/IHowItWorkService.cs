using DataArchitect.TransportMongoDb.Dtos.HowItWorkDtos;

namespace DataArchitect.TransportMongoDb.Services.HowItWorkServices
{
    public interface IHowItWorkService
    {
        Task<List<ResultHowItWorkDto>> GetAllHowItWorkAsync();
        Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto);
        Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto);
        Task<GetHowItWorkByIdDto> GetHowItWorkByIdAsync(string id);
        Task DeleteHowItWorkAsync(string id);
    }
}
