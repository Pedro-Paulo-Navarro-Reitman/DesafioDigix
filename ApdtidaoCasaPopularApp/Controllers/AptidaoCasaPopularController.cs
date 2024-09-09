using AptidaoCasaPopularApplication.Services;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AptidaoCasaPopularWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AptidaoCasaPopularController : Controller
    {
        private readonly IPontuacaoFamiliaService _pontuacaoFamiliaService;
        private readonly ILogger<AptidaoCasaPopularController> _logger;
        public AptidaoCasaPopularController(IPontuacaoFamiliaService pontuacaoFamiliaService, ILogger<AptidaoCasaPopularController> logger)
        {
            _pontuacaoFamiliaService = pontuacaoFamiliaService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult RetornarFamiliasOrdenadas() 
        {
            try
            {
                var ListaDeFamiliasOrdenada = _pontuacaoFamiliaService.FamiliasOrdenadasPorPontuacao();
                _logger.LogInformation("Famílias ordenadas retornadas com sucesso.");
                return Ok(ListaDeFamiliasOrdenada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar famílias ordenadas.");
                return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde.");
            }
        }

    }
}
