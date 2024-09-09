using AptidaoCasaPopularApplication.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.AptidaoCasaPopularApplication.Tests.Services.Tests
{
    public class PontuacaoFamiliaServiceTest
    {
        [Fact]
        public void CalculateTotalScoreTeste()
        {

            var mockCriterio = new Mock<ICriterioDePontuacao>();
            mockCriterio.Setup(c => c.CalcularPontuacao(It.IsAny<Familia>())).Returns(10);

            var familiaRepository = new Mock<IFamiliaRepository>();
            var service = new PontuacaoFamiliaService(new[] { mockCriterio.Object }, familiaRepository.Object);

            var familia = new Familia();

            var score = service.CalculateTotalScore(familia);

            Assert.Equal(10, score);
        }

        [Fact]
        public void FamiliasOrdenadasPorPontuacaoTeste()
        {

            var mockCriterio = new Mock<ICriterioDePontuacao>();
            mockCriterio.Setup(c => c.CalcularPontuacao(It.IsAny<Familia>())).Returns((Familia f) => (int)f.Renda);

            var mockFamiliaRepository = new Mock<IFamiliaRepository>();
            var familias = new List<Familia>
            {
                new Familia { Renda = 1200, QuantidadeDependentes = 2 },
                new Familia { Renda = 800, QuantidadeDependentes = 3 },
                new Familia { Renda = 2000, QuantidadeDependentes = 1 }
            };

            mockFamiliaRepository.Setup(repo => repo.GetAllFamilias()).Returns(familias);

            var service = new PontuacaoFamiliaService(new[] { mockCriterio.Object }, mockFamiliaRepository.Object);

            var resultado = service.FamiliasOrdenadasPorPontuacao().ToList(); 

            Assert.Equal(2000, resultado[0].Renda); 
            Assert.Equal(1200, resultado[1].Renda); 
            Assert.Equal(800, resultado[2].Renda);  
        }

    }
}
