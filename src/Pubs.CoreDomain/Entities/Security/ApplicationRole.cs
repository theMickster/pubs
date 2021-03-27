using System.Collections.Generic;
using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities.Security
{
    public class ApplicationRole : BaseEntity
    {
        public string RoleName { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
