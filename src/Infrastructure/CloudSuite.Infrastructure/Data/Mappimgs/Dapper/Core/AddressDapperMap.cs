using CloudSuite.Modules.Domain.Models.Core;
using Dapper.FluentMap.Dommel.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Data.Mappimgs.Dapper.Core
{
    public class AddressDapperMap : DommelEntityMap<Address>
    {
        private readonly DbContext _dbContext;

        public AddressDapperMap(DbContext dbContext)
        {
            _dbContext = dbContext;
            ToTable("Addresses");
            Map(p => p.Id).IsKey();
            

        }

        public void Insert(Address address)
        {
            const string insertQuery = @"
                INSERT INTO Addresses (ContactName, AddressLine1, DistrictId)
                VALUES (@ContactName, @AddressLine1, @DistrictId)";

            
        }
        
    }
}