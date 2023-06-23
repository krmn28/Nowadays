using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities;

namespace Nowadays.Api.DataAccess.Repositories.DutyRepositories
{
    public class DutyRepository:Repository<Duty>, IDutyRepository
    {
        public DutyRepository(NowadaysDbContext context) : base(context)
        {
            
        }
    }
    
}