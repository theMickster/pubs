using Pubs.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pubs.CoreDomain.Entities.Security
{
    public class ApplicationUser : BaseEntity
    {
        public ApplicationUser(int applicationUserStatusId, DateTime? lastSuccessfulLogin)
        {
            ApplicationUserStatusId = applicationUserStatusId;
            LastSuccessfulLogin = lastSuccessfulLogin;
        }

        public string UserName { get; set; }

        public string UserPrincipalName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public int ApplicationUserStatusId { get; }

        public DateTime? LastSuccessfulLogin { get; private set; }
        
        public bool IsActive => ApplicationUserStatusId == 1001;
        
        public bool IsInactive => ApplicationUserStatusId == 1002;
        
        public bool IsLocked => ApplicationUserStatusId == 1003;

        public ApplicationUserStatus ApplicationUserStatus { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public void UpdateLastSuccessfulLogin(DateTime lastLoginDate)
        {
            if (LastSuccessfulLogin == null)
            {
                LastSuccessfulLogin = lastLoginDate;
            }
            else
            {
                if (LastSuccessfulLogin > lastLoginDate)
                {
                    throw new ArgumentOutOfRangeException(nameof(lastLoginDate),"The date parameter cannot be before the current value");
                }

                LastSuccessfulLogin = lastLoginDate;
            }
        }
    }
}
