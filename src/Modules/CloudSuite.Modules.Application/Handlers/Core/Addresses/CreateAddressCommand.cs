﻿using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using AddressEntity = CloudSuite.Modules.Domain.Models.Core.Address;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Handlers.Core.Addresses
{
  public class CreateAddressCommand : IRequest<CreateAddressResponse>
  {
    public Guid Id { get; private set; }

    public string? ContactName { get; set; }

    public string? AddressLine1 { get; set; }

    // public City? City { get; set; }

    public CreateAddressCommand()
    {
      Id = Guid.NewGuid();
    }

    public AddressEntity GetEntity()
    {
      return new AddressEntity(
          this.AddressLine1,
          this.City
      );
    }
  }
}
