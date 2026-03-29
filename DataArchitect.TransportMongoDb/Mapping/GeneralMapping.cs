using AutoMapper;
using DataArchitect.TransportMongoDb.Dtos.AboutDtos;
using DataArchitect.TransportMongoDb.Dtos.BrandDtos;
using DataArchitect.TransportMongoDb.Dtos.GetInTouchDtos;
using DataArchitect.TransportMongoDb.Dtos.HowItWorkDtos;
using DataArchitect.TransportMongoDb.Dtos.OfferDtos;
using DataArchitect.TransportMongoDb.Dtos.ProjectSectionDtos;
using DataArchitect.TransportMongoDb.Dtos.QuestionDtos;
using DataArchitect.TransportMongoDb.Dtos.ShipmentDtos;
using DataArchitect.TransportMongoDb.Dtos.ShipmentTrackingDtos;
using DataArchitect.TransportMongoDb.Dtos.SliderDtos;
using DataArchitect.TransportMongoDb.Dtos.TestimonialDtos;
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

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetBrandByIdDto>().ReverseMap();

            CreateMap<Offer, ResultOfferDto>().ReverseMap();
            CreateMap<Offer, CreateOfferDto>().ReverseMap();
            CreateMap<Offer, UpdateOfferDto>().ReverseMap();
            CreateMap<Offer, GetOfferByIdDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutByIdDto>().ReverseMap();

            CreateMap<GetInTouch, ResultGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouch, UpdateGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouch, CreateGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouch, GetGetInTouchByIdDto>().ReverseMap();

            CreateMap<HowItWork, ResultHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork, UpdateHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork, CreateHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork, GetHowItWorkByIdDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();

            CreateMap<ProjectSection, ResultProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection, UpdateProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection, CreateProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection, GetProjectSectionByIdDto>().ReverseMap();

            CreateMap<Question, ResultQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Question, GetQuestionByIdDto>().ReverseMap();

            CreateMap<Shipment, ResultShipmentDto>().ReverseMap();
            CreateMap<Shipment, CreateShipmentDto>().ReverseMap();
            CreateMap<Shipment, UpdateShipmentDto>().ReverseMap();
            CreateMap<Shipment, GetShipmentByIdDto>().ReverseMap();


            CreateMap<ShipmentTracking, CreateShipmentTrackingDto>().ReverseMap();
            CreateMap<ShipmentTracking, ResultShipmentTrackingDto>().ReverseMap();
            CreateMap<ShipmentTracking, UpdateShipmentTrackingDto>().ReverseMap();

        }
    }
}
