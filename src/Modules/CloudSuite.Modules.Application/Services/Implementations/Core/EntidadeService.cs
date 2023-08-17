﻿using System.Xml;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Application.Events.Core;
using MediatR;
using NetDevPack.Domain;
using NetDevPack.Data;
using CloudSuite.Modules.Domain.Contracts.Core;
using NetDevPack.Mediator;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class EntidadeService : IEntidadeService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<EntidadeService> _logger;
        private readonly IConfiguration _configuration;
        
        

        public EntidadeService(
            IEntityRepository entityRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<EntidadeService> logger,
            IConfiguration configuration)

        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        
        public async Task<Entidade> GetByName(string name)
        {
            _logger.LogInformation($"Getting Entity by Name {name}");
            return _mapper.Map<Entidade>(await _entityRepository.GetByName(name));
        }

        public async Task<Entidade> GetBySlug(string slug)
        {
            _logger.LogInformation($"Getting Entity by Slug {slug}");
            return _mapper.Map<Entidade>(await _entityRepository.GetBySlug(slug));
        }

        

    }
}
