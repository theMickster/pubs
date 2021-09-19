﻿using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Application.Interfaces.Repositories
{
    public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser, int>
    {
    }
}