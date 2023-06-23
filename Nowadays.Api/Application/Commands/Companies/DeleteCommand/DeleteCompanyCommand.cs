using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nowadays.Api.DataAccess.Repositories;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;

namespace Nowadays.Api.Application.Commands.Companies.DeleteCommand
{
    public class DeleteCompanyCommandRequest:IRequest<DeleteCompanyCommandResponse>
    {
        public int Id { get; set; }
        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, DeleteCompanyCommandResponse>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
            {
                var company = await _companyRepository.Get(c => c.Id == request.Id);
                if(company is not null)
                {
                        
                        var result = await _companyRepository.Delete(company);
                         await _unitOfWork.SaveAsync();
                          return result ?  new(){Message ="Company deleted successed", Successed=result }
                          : new() {Message = "Not deleted company", Successed= result};
                }
                else
                {
                    return new(){ Message = "Not found company", Successed = false };
                }
            }
        }
    }
}