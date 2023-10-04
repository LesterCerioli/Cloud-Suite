using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using MediatR;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class UserService : IUserService
    {
        public UserService(
            IUserRepository userRepository,
            IMediatorHandler mediator,
            IMapper mapper

        )
        {
            _mapper = mapper;
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByEmailAsync(Email email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<User> GetUserByCpfAsync(Cpf cpf)
        {
            return await _userRepository.GetByCpf(cpf);
        }
        
    }
}