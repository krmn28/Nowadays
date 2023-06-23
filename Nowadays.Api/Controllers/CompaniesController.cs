using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nowadays.Api.Application.Commands.Companies.CreateCommand;
using Nowadays.Api.Application.Commands.Companies.DeleteCommand;
using Nowadays.Api.Application.Commands.Companies.UpdateCommand;
using Nowadays.Api.Application.Queries.Companies.GetAllQuery;
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
         private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CreateCompanyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany([FromRoute] DeleteCompanyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);

        }


    }
}