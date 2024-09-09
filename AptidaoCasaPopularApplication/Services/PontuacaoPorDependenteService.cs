using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptidaoCasaPopularApplication.Services
{
    public class PontuacaoPorDependenteService: ICriterioDePontuacao
    {
        public int CalcularPontuacao(Familia familia)
        {
            if (familia.QuantidadeDependentes >= 3) return 3;
            if (familia.QuantidadeDependentes >= 1) return 2;
            return 0;
        }
    }
}
