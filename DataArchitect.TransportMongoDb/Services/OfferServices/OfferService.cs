using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.OfferDtos;
using DataArchitect.TransportMongoDb.Entities;
using DataArchitect.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DataArchitect.TransportMongoDb.Services.OfferServices
{
    public class OfferService : IOfferService   
    {
        private readonly IMongoCollection<Offer> _OfferCollection;
        private readonly IMapper _mapper;

        public OfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client değişken aracılığıyla mongodb bağlantısına erişim sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);// database değişken aracılığıyla clienttaki bağlantı üzerinden veri tabanına erişiliyor
            _OfferCollection = database.GetCollection<Offer>(_databaseSettings.OfferCollectionName);//database aracılığıyla tabloya erişildi
            _mapper = mapper;
        }
        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var value = _mapper.Map<Offer>(createOfferDto);
            await _OfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteOfferAsync(string id)
        {
            await _OfferCollection.DeleteOneAsync(x => x.OfferId == id);
        }

        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var values = await _OfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDto>>(values);
        }

        public async Task<GetOfferByIdDto> GetOfferByIdAsync(string id)
        {
            var value = await _OfferCollection.Find(x => x.OfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetOfferByIdDto>(value);
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var values = _mapper.Map<Offer>(updateOfferDto);
            await _OfferCollection.FindOneAndReplaceAsync(x => x.OfferId == updateOfferDto.OfferId, values);
        }
    }
}
