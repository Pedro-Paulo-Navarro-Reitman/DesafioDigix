using Infra.Repositories;
using Infra.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Infra.Tests
{
    public class FamiliaRepositoryTest
    {
        [Fact]
        public void GetAllFamiliasTeste()
        {
            var databaseSettings = new DatabaseSettings { ConnectionString = "bancoDeTestes" };
            IOptions<DatabaseSettings> options = Options.Create(databaseSettings);
            var repository = new FamiliaRepository(options);
            var result = repository.GetAllFamilias();
            Assert.NotNull(result); 

        }
    }
}
