using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.HowItWorkDtos;
using DataArchitect.TransportMongoDb.Entities;
using DataArchitect.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DataArchitect.TransportMongoDb.Services.HowItWorkServices
{
    public class HowItWorkService : IHowItWorkService
    {
        private readonly IMongoCollection<HowItWork> _HowItWorkCollection;
        private readonly IMapper _mapper;

        public HowItWorkService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client değişken aracılığıyla mongodb bağlantısına erişim sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);// database değişken aracılığıyla clienttaki bağlantı üzerinden veri tabanına erişiliyor
            _HowItWorkCollection = database.GetCollection<HowItWork>(_databaseSettings.HowItWorkCollectionName);//database aracılığıyla tabloya erişildi
            _mapper = mapper;
        }
        public async Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto)
        {
            var value = _mapper.Map<HowItWork>(createHowItWorkDto);
            await _HowItWorkCollection.InsertOneAsync(value);
        }

        public async Task DeleteHowItWorkAsync(string id)
        {
            await _HowItWorkCollection.DeleteOneAsync(x => x.HowItWorkId == id);
        }

        public async Task<List<ResultHowItWorkDto>> GetAllHowItWorkAsync()
        {
            var values = await _HowItWorkCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultHowItWorkDto>>(values);
        }

        public async Task<GetHowItWorkByIdDto> GetHowItWorkByIdAsync(string id)
        {
            var value = await _HowItWorkCollection.Find(x => x.HowItWorkId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetHowItWorkByIdDto>(value);
        }

        public async Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto)
        {
            var values = _mapper.Map<HowItWork>(updateHowItWorkDto);
            await _HowItWorkCollection.FindOneAndReplaceAsync(x => x.HowItWorkId == updateHowItWorkDto.HowItWorkId, values);
        }
    }
}
