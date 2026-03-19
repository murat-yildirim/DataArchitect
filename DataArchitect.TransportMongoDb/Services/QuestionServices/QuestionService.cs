using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.QuestionDtos;
using DataArchitect.TransportMongoDb.Entities;
using DataArchitect.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DataArchitect.TransportMongoDb.Services.QuestionServices
{
    public class QuestionService : IQuestionService
    {
        private readonly IMongoCollection<Question> _QuestionCollection;
        private readonly IMapper _mapper;

        public QuestionService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client değişken aracılığıyla mongodb bağlantısına erişim sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);// database değişken aracılığıyla clienttaki bağlantı üzerinden veri tabanına erişiliyor
            _QuestionCollection = database.GetCollection<Question>(_databaseSettings.QuestionCollectionName);//database aracılığıyla tabloya erişildi
            _mapper = mapper;
        }
        public async Task CreateQuestionAsync(CreateQuestionDto createQuestionDto)
        {
            var value = _mapper.Map<Question>(createQuestionDto);
            await _QuestionCollection.InsertOneAsync(value);
        }

        public async Task DeleteQuestionAsync(string id)
        {
            await _QuestionCollection.DeleteOneAsync(x => x.QuestionId == id);
        }

        public async Task<List<ResultQuestionDto>> GetAllQuestionAsync()
        {
            var values = await _QuestionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultQuestionDto>>(values);
        }

        public async Task<GetQuestionByIdDto> GetQuestionByIdAsync(string id)
        {
            var value = await _QuestionCollection.Find(x => x.QuestionId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetQuestionByIdDto>(value);
        }

        public async Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto)
        {
            var values = _mapper.Map<Question>(updateQuestionDto);
            await _QuestionCollection.FindOneAndReplaceAsync(x => x.QuestionId == updateQuestionDto.QuestionId, values);
        }
    }
}
