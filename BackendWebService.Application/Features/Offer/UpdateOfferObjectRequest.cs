namespace Application.Features
{
    public class UpdateOfferObjectRequest
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public int ObjectId { get; set; }
        public string ObjectType { get; set; }
    }
}
