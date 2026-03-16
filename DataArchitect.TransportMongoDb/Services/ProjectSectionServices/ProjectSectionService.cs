using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.ProjectSectionDtos;
using DataArchitect.TransportMongoDb.Entities;
using DataArchitect.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DataArchitect.TransportMongoDb.Services.ProjectSectionServices
{
    public class ProjectSectionService : IProjectSectionService
    {
        private readonly IMongoCollection<ProjectSection> _ProjectSectionCollection;
        private readonly IMapper _mapper;

        public ProjectSectionService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client değişken aracılığıyla mongodb bağlantısına erişim sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);// database değişken aracılığıyla clienttaki bağlantı üzerinden veri tabanına erişiliyor
            _ProjectSectionCollection = database.GetCollection<ProjectSection>(_databaseSettings.ProjectSectionCollectionName);//database aracılığıyla tabloya erişildi
            _mapper = mapper;
        }
        public async Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto)
        {
            var value = _mapper.Map<ProjectSection>(createProjectSectionDto);
            await _ProjectSectionCollection.InsertOneAsync(value);
        }

        public async Task DeleteProjectSectionAsync(string id)
        {
            await _ProjectSectionCollection.DeleteOneAsync(x => x.ProjectSectionId == id);
        }

        public async Task<List<ResultProjectSectionDto>> GetAllProjectSectionAsync()
        {
            var values = await _ProjectSectionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProjectSectionDto>>(values);
        }

        public async Task<GetProjectSectionByIdDto> GetProjectSectionByIdAsync(string id)
        {
            var value = await _ProjectSectionCollection.Find(x => x.ProjectSectionId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProjectSectionByIdDto>(value);
        }

        public async Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto)
        {
            var values = _mapper.Map<ProjectSection>(updateProjectSectionDto);
            await _ProjectSectionCollection.FindOneAndReplaceAsync(x => x.ProjectSectionId == updateProjectSectionDto.ProjectSectionId, values);
        }
    }
}
