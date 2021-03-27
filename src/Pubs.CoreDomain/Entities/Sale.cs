using System;
using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Sale : BaseEntity
    {
        public string StoreCode { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }

        public string PaymentTerms { get; set; }

        public int StoreId { get; set; }

        public int TitleId { get; set; }

        public string TitleCode { get; set; }

        public Store Store { get; set; }

        public Title Title { get; set; }
    }
}