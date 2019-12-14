﻿using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Author : BaseEntity
    {
        public string AuthorCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public bool Contract { get; set; }
    }
}