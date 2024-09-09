using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Familia
    {
        public decimal Renda { get; set; }
        public int QuantidadeDependentes { get; set; }

        public int? Pontuacao { get; set; }

    }
}
