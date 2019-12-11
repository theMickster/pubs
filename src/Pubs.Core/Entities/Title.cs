using System;
using System.Collections.Generic;
using Pubs.SharedKernel.Base;

namespace Pubs.Core.Entities
{
    public class Title : BaseEntity
    {
        public string TitleCode { get; set; }

        public string TitleName { get; set; }

        public string TitleType { get; set; }

        public int PublisherId { get; set; }

        public string PublisherCode { get; set; }

        public decimal Price { get; set; }

        public decimal Advance { get; set; }

        public int Royalty { get; set; }

        public int YearToDateSales { get; set; }

        public string Notes { get; set; }

        public DateTime PublishedDate { get; set; }

        public ICollection<Royalty> Royalties { get; set; }
    }
}