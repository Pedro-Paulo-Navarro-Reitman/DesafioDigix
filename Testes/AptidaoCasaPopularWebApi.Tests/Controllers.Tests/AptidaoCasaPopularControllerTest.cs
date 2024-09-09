using AptidaoCasaPopularApplication.Services;
using AptidaoCasaPopularWebApi.Controllers;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.AptidaoCasaPopularWebApi.Tests.Controllers.Tests
{
    public class AptidaoCasaPopularControllerTest
    {
        private readonly Mock<IPontuacaoFamiliaService> _mockPontuacaoFamiliaService;
        private readonly Mock<ILogger<AptidaoCasaPopularController>> _mockLogger;
        private readonly AptidaoCasaPopularController _controller;

        public AptidaoCasaPopularControllerTest()
        {
            _mockPontuacaoFamiliaService = new Mock<IPontuacaoFamiliaService>();
            _mockLogger = new Mock<ILogger<AptidaoCasaPopularController>>();
            _controller = new AptidaoCasaPopularController(_mockPontuacaoFamiliaService.Object, _mockLogger.Object);
        }

        [Fact]
        public void RetornarFamiliasOrdenadas_DeveRetornarOkComFamiliasOrdenadas()
        {
            // Arrange
            var familias = new List<Familia>
            {
                new Familia { Renda = 800, QuantidadeDependentes = 2, Pontuacao = 5 },
                new Familia { Renda = 1200, QuantidadeDependentes = 3, Pontuacao = 3 }
            };

            _mockPontuacaoFamiliaService
                .Setup(service => service.FamiliasOrdenadasPorPontuacao())
                .Returns(familias);


            var result = _controller.RetornarFamiliasOrdenadas() as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var resultadoFamilias = result.Value as IEnumerable<Familia>;
            Assert.NotNull(resultadoFamilias);
            Assert.Equal(2, resultadoFamilias.Count());
            Assert.Equal(5, resultadoFamilias.First().Pontuacao);
            Assert.Equal(3, resultadoFamilias.Last().Pontuacao);
        }

        [Fact]
        public void RetornarFamiliasOrdenadas_DeveRetornarStatus500QuandoException()
        {

            _mockPontuacaoFamiliaService
                .Setup(service => service.FamiliasOrdenadasPorPontuacao())
                .Throws(new Exception("Erro inesperado"));


            var result = _controller.RetornarFamiliasOrdenadas() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde.", result.Value);
        }
    }
}
