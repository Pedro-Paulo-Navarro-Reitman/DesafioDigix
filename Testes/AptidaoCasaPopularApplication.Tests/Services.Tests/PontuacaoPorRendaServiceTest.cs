using AptidaoCasaPopularApplication.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.AptidaoCasaPopularApplication.Tests.Services.Tests
{
    public class PontuacaoPorRendaServiceTest
    {
        [Fact]
        public void CalcularPontuacao_DeveRetornar5_SeRendaFor900OuMenor()
        {
            var familia = new Familia { Renda = 900 };
            var pontuacaoService = new PontuacaoPorRendaService();

            var pontuacao = pontuacaoService.CalcularPontuacao(familia);
            Assert.Equal(5, pontuacao);
        }

        [Fact]
        public void CalcularPontuacao_DeveRetornar3_SeRendaForEntre901E1500()
        {

            var familia = new Familia { Renda = 1200 };
            var pontuacaoService = new PontuacaoPorRendaService();

            var pontuacao = pontuacaoService.CalcularPontuacao(familia);

            Assert.Equal(3, pontuacao);
        }

        [Fact]
        public void CalcularPontuacao_DeveRetornar0_SeRendaForAcimaDe1500()
        {

            var familia = new Familia { Renda = 1600 };
            var pontuacaoService = new PontuacaoPorRendaService();

            var pontuacao = pontuacaoService.CalcularPontuacao(familia);

            Assert.Equal(0, pontuacao);
        }
    }
}
