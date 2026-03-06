namespace DataArchitect.TransportMongoDb.Dtos.BrandDtos
{
    public class UpdateBrandDto
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public bool IssStatus { get; set; }
    }
}
