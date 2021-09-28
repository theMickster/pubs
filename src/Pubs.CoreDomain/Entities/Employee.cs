using System;
using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int JobId { get; set; }

        public byte JobLevel { get; set; }

        public int PublisherId { get; set; }

        public string PublisherCode { get; set; }

        public Publisher Publisher { get; set; }

        public DateTime HireDate { get; set; }

        public Job Job { get; set; }
    }
}