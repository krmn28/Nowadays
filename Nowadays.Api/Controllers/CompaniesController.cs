using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nowadays.Api.DataAccess.Repositories;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;
using Nowadays.Api.Entities;
using Nowadays.Api.VMModels.Companies;

namespace Nowadays.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
         private readonly ICompanyRepository _companyRepository;
         private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CreateCompanyViewModel viewModel)
        {
             Company company = new()
             {
                Name = viewModel.Name,
                Description = viewModel.Description
             };
            var result = await _companyRepository.AddAsync(company);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyRepository.GetAll().ToListAsync();
            return Ok(result);

        }


    }
}