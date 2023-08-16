namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class RoboEmailService : IRoboEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        

        public RoboEmailService(
            IRoboEmailRepository roboEmailRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _roboEmailRepository = roboEmailRepository;
            _mapper = mapper;
            _mediator = mediator;
            
        }
             

        public async Task<RoboEmailViewModel> GetBySubject(string subject)
        {
            return _mapper.Map<EmailViewModel>(await _emailRepository.GetBySubject(subject));
        }
               
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateEmailCommand commandCreate)
        {
            await _emailRepository.Add(commandCreate.GetEntity());
        }


        

        
        
    }
}