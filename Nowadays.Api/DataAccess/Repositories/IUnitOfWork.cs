using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nowadays.Api.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}