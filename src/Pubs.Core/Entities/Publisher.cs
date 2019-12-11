using System.Collections.Generic;
using Pubs.SharedKernel.Base;

namespace Pubs.Core.Entities
{
    public class Publisher : BaseEntity
    {
        public string PublisherCode { get; set; }

        public string PublisherName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<PublisherLogo> PublisherLogos { get; set; }

        public ICollection<Title> Titles { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}