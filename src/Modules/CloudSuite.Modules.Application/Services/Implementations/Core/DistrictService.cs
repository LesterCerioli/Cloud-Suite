using CloudSuite.Modules.Application.Handlers.Districts;
using CloudSuite.Modules.Application.Services.Contracts;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorhandler _mediator;
        
        public DistrictService(
            IDistrictRepository districtRepoisitory,
            IMediatorHandler mediator,
            IMapper mapper
        )
        {
            _districtRepository = districtRepoisitory;
            _mapper = mapper;
            _mediator = mediator;
        }
        
    }
}