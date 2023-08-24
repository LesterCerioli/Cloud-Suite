using CloudSuite.Modules.Application.Handlers.Core.Cities.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Cities.Requests
{
    public class CheckCityExistsByCityNameRequest : IRequest<CheckCityExistsByCityNameResponse>
    {
        public Guid Id { get; private set; }
        public string? CityName { get; set; }
        public CheckCityExistsByCityNameRequest(string cityName)
        {
            Id = Guid.NewGuid();
            CityName = cityName;
        }
    }
}
