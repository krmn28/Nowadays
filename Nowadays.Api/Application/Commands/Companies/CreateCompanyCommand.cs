using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nowadays.Api.DataAccess.Repositories;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;
using Nowadays.Api.Entities;
using Nowadays.Api.VMModels.Companies;

namespace Nowadays.Api.Application.Commands.Companies
{
    public  class CreateCompanyCommandRequest : IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
            {
                 Company mappedCompany = _mapper.Map<Company>(request);
                 bool result = await _companyRepository.AddAsync(mappedCompany);

                  await _unitOfWork.SaveAsync();
                 return result ? new(){Message = "Kayıt oluşturuldu", Successed=result} 
                 : new(){Message = "İstenmeyen bir hata oluştu", Successed=result}; 

            }
        }
    }
}