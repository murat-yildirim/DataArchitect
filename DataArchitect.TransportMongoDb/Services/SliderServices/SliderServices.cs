using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.SliderDtos;
using DataArchitect.TransportMongoDb.Entities;
using DataArchitect.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DataArchitect.TransportMongoDb.Services.SliderServices
{
    public class SliderServices : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client değişken aracılığıyla mongodb bağlantısına erişim sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);// database değişken aracılığıyla clienttaki bağlantı üzerinden veri tabanına erişiliyor
            _sliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);//database aracılığıyla tabloya erişildi
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(x => x.SliderId == id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var values = await _sliderCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task<GetSliderByIdDto> GetSliderByIdAsync(string id)
        {
            var value = await _sliderCollection.Find(x => x.SliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSliderByIdDto>(value);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var values = _mapper.Map<Slider>(updateSliderDto);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDto.SliderId, values);
        }
    }
}
