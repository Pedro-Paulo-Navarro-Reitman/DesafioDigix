using AptidaoCasaPopularApplication.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.AptidaoCasaPopularApplication.Tests.Services.Tests
{
    public class PontuacaoPorDependenteServiceTest
    {
        [Fact]
        public void CalcularPontuacao_DeveRetornar3_SeFamiliaTem3OuMaisDependentes()
        {
            var familia = new Familia { QuantidadeDependentes = 3 };
            var pontuacaoService = new PontuacaoPorDependenteService();

            var pontuacao = pontuacaoService.CalcularPontuacao(familia);

            Assert.Equal(3, pontuacao);
        }

        [Fact]
        public void CalcularPontuacao_DeveRetornar2_SeFamiliaTem1Ou2Dependentes()
        {
            var familia = new Familia { QuantidadeDependentes = 2 };
            var pontuacaoService = new PontuacaoPorDependenteService();

            var pontuacao = pontuacaoService.CalcularPontuacao(familia);

            Assert.Equal(2, pontuacao);
        }

        [Fact]
        public void CalcularPontuacao_DeveRetornar0_SeFamiliaTem0Dependentes()
        {
            var familia = new Familia { QuantidadeDependentes = 0 };
            var pontuacaoService = new PontuacaoPorDependenteService();

            var pontuacao = pontuacaoService.CalcularPontuacao(familia);

            Assert.Equal(0, pontuacao);
        }
    }
}
