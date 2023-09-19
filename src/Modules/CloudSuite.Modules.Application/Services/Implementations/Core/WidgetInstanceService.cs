using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class WidgetInstanceService : IWidgetInstanceService
    {
        public WidgetInstanceServiceidgetInstanceService(
            IWidgetInstancceRepository widgetInstancceRepository,
            IMediator mediator,
            IMapper mapper
            )
        {
            _widgetInstanceRepository = widgetInstancceRepository;
            _mapper = mapper;
            _mediator = mediator;

        }
    }
}
