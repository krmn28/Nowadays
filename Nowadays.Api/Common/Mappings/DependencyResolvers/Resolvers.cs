using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;
using Nowadays.Api.DataAccess.Repositories;

namespace Nowadays.Api.Common.Mappings.DependencyResolvers
{
    public static class Resolvers
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
             services.AddMediatR(typeof(Resolvers));
             services.AddScoped<ICompanyRepository, CompanyRepository>();
             services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}