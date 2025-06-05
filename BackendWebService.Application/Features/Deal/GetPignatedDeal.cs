using Application.Features.Common;

namespace Application.Features.Deal
{
    public class GetPignatedDeal
    {
        public int Id { get; set; }

        public string Proposal { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

