using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountType { get; set; }

        public int StoreId { get; set; }

        public string StoreCode { get; set; }

        public int LowQuantity { get; set; }

        public int HighQuantity { get; set; }

        public decimal DiscountAmount { get; set; }

        public Store Store { get; set; }
        
    }
}