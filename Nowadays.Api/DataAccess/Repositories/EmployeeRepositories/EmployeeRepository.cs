using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nowadays.Api.Entities;

namespace Nowadays.Api.DataAccess.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}