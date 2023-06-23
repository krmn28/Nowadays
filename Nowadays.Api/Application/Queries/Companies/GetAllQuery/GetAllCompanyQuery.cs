using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nowadays.Api.DataAccess.Repositories;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;
using Nowadays.Api.Entities;

namespace Nowadays.Api.Application.Queries.Companies.GetAllQuery
{
    public class GetAllCompanyQueryRequest:IRequest<List<GetAllCompanyQueryResponse>>
    {
        public class GetAllCompanyQueryHandler:IRequestHandler<GetAllCompanyQueryRequest, List<GetAllCompanyQueryResponse>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAllCompanyQueryHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<List<GetAllCompanyQueryResponse>> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
            {
                var companies = await _companyRepository.GetAll().ToListAsync();
                var mappedCompanies = _mapper.Map<List<GetAllCompanyQueryResponse>>(companies);
                return mappedCompanies;
            }
        }
    }
}