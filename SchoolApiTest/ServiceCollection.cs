using AutoMapper;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest
{
    [CollectionDefinition("Services")]
    public class ServiceCollection : ICollectionFixture<ServiceCollection>
    {
        public ServiceCollection()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            mapper = configuration.CreateMapper();
        }
        public IMapper mapper { get; }
    }
}
