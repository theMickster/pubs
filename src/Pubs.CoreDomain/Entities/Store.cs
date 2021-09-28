using System.Collections.Generic;
using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Store : BaseEntity
    {
        public string StoreCode { get; set; }

        public string StoreName { get; set; }

        public string StoreAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
        
        public ICollection<Discount> Discounts { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}