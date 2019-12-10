using System.Collections.Generic;
using Pubs.SharedKernel.Base;

namespace Pubs.Core.Entities
{
    public class Job : BaseEntity
    {
        public string JobDescription { get; set; }

        public int MinimumLevel { get; set; }

        public int MaximumLevel { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}