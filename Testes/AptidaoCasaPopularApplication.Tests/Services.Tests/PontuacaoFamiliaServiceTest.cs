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
        public void CalculateTotalScore_CalculaPontuacaoTotalCorretamente()
        {

            var mockCriterio1 = new Mock<ICriterioDePontuacao>();
            mockCriterio1.Setup(c => c.CalcularPontuacao(It.IsAny<Familia>())).Returns(10);

            var mockCriterio2 = new Mock<ICriterioDePontuacao>();
            mockCriterio2.Setup(c => c.CalcularPontuacao(It.IsAny<Familia>())).Returns(20);

            var familia = new Familia();
            var criterios = new List<ICriterioDePontuacao> { mockCriterio1.Object, mockCriterio2.Object };
            var service = new PontuacaoFamiliaService(criterios, null);


            var totalScore = service.CalculateTotalScore(familia);


            Assert.Equal(30, totalScore);
        }

        [Fact]
        public void FamiliasOrdenadasPorPontuacao_OrdenaFamiliasPorPontuacao()
        {
           
            var familias = new List<Familia>
            {
                new Familia { Renda = 800, QuantidadeDependentes = 3 },    
                new Familia { Renda = 3000, QuantidadeDependentes = 2 },   
                new Familia { Renda = 1500, QuantidadeDependentes = 1 }    
            };

            
            var mockRepository = new Mock<IFamiliaRepository>();
            mockRepository.Setup(r => r.GetAllFamilias()).Returns(familias);

            
            var criterios = new List<ICriterioDePontuacao>
            {
                new PontuacaoPorRendaService(),
                new PontuacaoPorDependenteService()
            };

            
            var service = new PontuacaoFamiliaService(criterios, mockRepository.Object);

            
            var familiasOrdenadas = service.FamiliasOrdenadasPorPontuacao().ToList();

            
            Assert.Equal(8, familiasOrdenadas[0].Pontuacao);  
            Assert.Equal(5, familiasOrdenadas[1].Pontuacao);  
            Assert.Equal(2, familiasOrdenadas[2].Pontuacao);  
        }

        [Fact]
        public void FamiliasOrdenadasPorPontuacao_ComListaVazia_RetornaListaVazia()
        {

            var mockRepository = new Mock<IFamiliaRepository>();
            mockRepository.Setup(r => r.GetAllFamilias()).Returns(new List<Familia>());

            var service = new PontuacaoFamiliaService(new List<ICriterioDePontuacao>(), mockRepository.Object);


            var familiasOrdenadas = service.FamiliasOrdenadasPorPontuacao().ToList();

  
            Assert.Empty(familiasOrdenadas);
        }

        [Fact]
        public void FamiliasOrdenadasPorPontuacao_ComUmaFamilia_RetornaEssaFamilia()
        {

            var familia = new Familia { Pontuacao = 15 };
            var familias = new List<Familia> { familia };

            var mockRepository = new Mock<IFamiliaRepository>();
            mockRepository.Setup(r => r.GetAllFamilias()).Returns(familias);

            var service = new PontuacaoFamiliaService(new List<ICriterioDePontuacao>(), mockRepository.Object);


            var familiasOrdenadas = service.FamiliasOrdenadasPorPontuacao().ToList();


            Assert.Single(familiasOrdenadas);
            Assert.Equal(familia.Pontuacao, familiasOrdenadas[0].Pontuacao);
        }

    }
}
