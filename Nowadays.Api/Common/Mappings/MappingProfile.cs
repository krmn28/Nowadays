using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nowadays.Api.Entities;
using Nowadays.Api.VMModels.Companies;
using Nowadays.Api.Application.Commands.Companies;
using Nowadays.Api.Application.Queries.Companies;

namespace Nowadays.Api.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommandRequest, Company>();
            CreateMap<Company, GetAllCompanyQueryResponse>();
        }
    }
}