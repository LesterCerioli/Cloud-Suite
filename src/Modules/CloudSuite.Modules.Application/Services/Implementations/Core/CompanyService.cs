using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Companies;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{/*
    public class CompanyService : ICompanyService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(
            ICompanyRepository companyRepository,
            IMapper mapper,
            IMediatorHandler mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }
        public async Task<CompanyViewModel> GetByCnpj(Cnpj cnpj)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByCnpj(cnpj));
        }

        public async Task<CompanyViewModel> GetByFantasyName(string fantasyName)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByFantasyName(fantasyName));
        }

        public async Task<CompanyViewModel> GetByRegisterName(string registerName)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByRegisterName(registerName));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateCompanyCommand commandCreate)
        {
            await _companyRepository.Add(commandCreate.GetEntity());
        }
    }
    */
}
