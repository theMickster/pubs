using Pubs.SharedKernel.Entities;

namespace Pubs.CoreDomain.Entities.Security
{
    public class ApplicationUserRole : BaseEntity
    {
        public int ApplicationUserId { get; set; }

        public int ApplicationRoleId { get; set; }

        public ApplicationRole ApplicationRole { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
