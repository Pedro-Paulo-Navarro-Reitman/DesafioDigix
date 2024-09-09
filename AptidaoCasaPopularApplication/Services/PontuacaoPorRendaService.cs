using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptidaoCasaPopularApplication.Services
{
    public class PontuacaoPorRendaService : ICriterioDePontuacao
    {
        public int CalcularPontuacao(Familia familia)
        {
            if (familia.Renda <= 900) return 5;
            if (familia.Renda <= 1500) return 3;
            return 0;
        }
    }
}
