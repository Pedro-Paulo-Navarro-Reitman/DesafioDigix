using Domain.Entities;
using Domain.Interfaces;
using Infra.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly DatabaseSettings _databaseSettings;

        public FamiliaRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }

        public IEnumerable<Familia> GetAllFamilias() 
        { 
            
            var families = new List<Familia>
            {
                new Familia { Renda = 800, QuantidadeDependentes = 2 },
                new Familia { Renda = 1200, QuantidadeDependentes = 3 },
                new Familia { Renda = 900, QuantidadeDependentes = 1 },
                new Familia { Renda = 3000, QuantidadeDependentes = 5 },
                new Familia { Renda = 1200, QuantidadeDependentes = 4 },
                new Familia { Renda = 1000, QuantidadeDependentes = 3 },
                new Familia { Renda = 600, QuantidadeDependentes = 3 },
                new Familia { Renda = 1200, QuantidadeDependentes = 4 },
            };

            return families;
        }
    }
}
