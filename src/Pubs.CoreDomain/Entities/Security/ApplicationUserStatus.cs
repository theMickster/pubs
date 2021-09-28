using System.Collections.Generic;
using Pubs.SharedKernel.Entities;


namespace Pubs.CoreDomain.Entities.Security
{
    public class ApplicationUserStatus : BaseEntity
    {
        public string StatusAbbreviation { get; set; }

        public string StatusName { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
