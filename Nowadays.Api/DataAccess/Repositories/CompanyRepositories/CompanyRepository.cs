using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities;

namespace Nowadays.Api.DataAccess.Repositories.CompanyRepositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}