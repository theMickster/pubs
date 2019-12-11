using System;
using Pubs.SharedKernel.Base;

namespace Pubs.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int JobId { get; set; }

        public int JobLevel { get; set; }

        public int PublisherId { get; set; }

        public string PublisherCode { get; set; }

        public Publisher Publisher { get; set; }

        public DateTime HireDate { get; set; }

        public Job Job { get; set; }
    }
}