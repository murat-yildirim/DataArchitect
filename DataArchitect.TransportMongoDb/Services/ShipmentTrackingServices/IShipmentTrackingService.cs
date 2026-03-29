using DataArchitect.TransportMongoDb.Dtos.ShipmentTrackingDtos;

namespace DataArchitect.TransportMongoDb.Services.ShipmentTrackingServices
{
    public interface IShipmentTrackingService
    {
        Task<List<ResultShipmentTrackingDto>> GetAllTrackingAsync(string trackingNumber);

        Task CreateTrackingAsync(CreateShipmentTrackingDto createDto);

        Task<ResultShipmentTrackingDto> GetTrackingByIndexAsync(string trackingNumber, int index);

        Task UpdateTrackingAsync(UpdateShipmentTrackingDto updateDto);

        Task DeleteTrackingAsync(string trackingNumber, int index);
    }
}
