using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nowadays.Api.DataAccess.Repositories;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;
using Nowadays.Api.Entities;

namespace Nowadays.Api.Application.Commands.Companies.UpdateCommand
{
    public class UpdateCompanyCommandRequest:IRequest<UpdateCompanyCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
            {
                var company = await _companyRepository.Get(c => c.Id == request.Id);
                if(company is not null)
                {
                        company.Name = string.IsNullOrEmpty(request.Name) ? company.Name : request.Name;
                        company.Description = string.IsNullOrEmpty(request.Description) ? company.Description : request.Description;
                        var result = await _unitOfWork.SaveAsync();
                          return result == 1 ?  new(){Message ="Company updated successed", Successed=true }
                          : new() {Message = "Not updated company", Successed= false};
                }
                else
                {
                    return new(){ Message = "Not found company", Successed = false };
                }
            }
        }
    }
}