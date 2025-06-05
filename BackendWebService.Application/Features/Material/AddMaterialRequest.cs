namespace BackendWebService.Application.Features
{
    public class AddMaterialRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
    }
}
