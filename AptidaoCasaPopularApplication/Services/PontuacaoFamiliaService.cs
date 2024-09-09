using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptidaoCasaPopularApplication.Services
{
    public class PontuacaoFamiliaService : IPontuacaoFamiliaService
    {
        private readonly IEnumerable<ICriterioDePontuacao> _criterioDePontuacao;
        private readonly IFamiliaRepository _familiaRepository;

        public PontuacaoFamiliaService(IEnumerable<ICriterioDePontuacao> criterioDePontuacao, IFamiliaRepository familiaRepository)
        {
            _criterioDePontuacao = criterioDePontuacao;
            _familiaRepository = familiaRepository;
        }

        public int CalculateTotalScore(Familia familia)
        {
            return _criterioDePontuacao.Sum(c => c.CalcularPontuacao(familia));
        }

        public IEnumerable<Familia> FamiliasOrdenadasPorPontuacao()
        {
        
            var familiasDoBanco =  _familiaRepository.GetAllFamilias();

            return familiasDoBanco
                .Select(familia =>
                {
                    familia.Pontuacao = CalculateTotalScore(familia);
                    return familia;
                })
                .OrderByDescending(familia => familia.Pontuacao);
        }
    }
}
