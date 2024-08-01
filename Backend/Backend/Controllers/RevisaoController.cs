using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class RevisaoController : BaseController
    {
        private readonly RevisaoService _revisaoService;

        public RevisaoController(RevisaoService revisaoService)
        {
            _revisaoService = revisaoService;
        }

        [HttpGet]
        public IEnumerable<Revisao> ObterTodasAsRevisoesPorVeiculo(int codigoVeiculo)
        {
            return _revisaoService.ObterTodasAsRevisoesPorVeiculo(codigoVeiculo);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverRegistroRevisao(int codigoRevisao)
        {
            if (await _revisaoService.RemoverRegistroRevisao(codigoRevisao))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> InserirRevisao(InserirRevisaoDTO revisaoDTO)
        {
            var revisao = new Revisao
            {
                CodigoVeiculo = revisaoDTO.CodigoVeiculo,
                DataRevisao = revisaoDTO.DataRevisao,
                Quilometragem = revisaoDTO.Quilometragem,
                ValorRevisao = revisaoDTO.ValorRevisao
            };

            return Ok(await _revisaoService.InserirRevisao(revisao));
        }
    }
}

