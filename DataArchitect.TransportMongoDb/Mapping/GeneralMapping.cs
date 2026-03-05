using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.SliderDtos;
using DataArchitect.TransportMongoDb.Entities;

namespace DataArchitect.TransportMongoDb.Mapping
{
    public class GeneralMapping :Profile
    {
        public GeneralMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderByIdDto>().ReverseMap();

        }
    }
}
