﻿using System.Collections.Generic;
using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities
{
    public class Job : BaseEntity
    {
        public string JobDescription { get; set; }

        public byte MinimumLevel { get; set; }

        public byte MaximumLevel { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}