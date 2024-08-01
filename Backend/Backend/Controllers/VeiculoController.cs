using Backend.DTO;
using Backend.Enums;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    public class VeiculoController : BaseController
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public IEnumerable<Veiculo> ObterTodosOsVeiculos(string Filtro = "")
        {
            return _veiculoService.RetornarTodosOsVeiculos(Filtro);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(InserirVeiculoDTO veiculoDTO)
        {
            try
            {
                if (veiculoDTO != null)
                {
                    var veiculo = new Veiculo
                    {
                        Ano = veiculoDTO.Ano,
                        Cor = veiculoDTO.Cor,
                        Modelo = veiculoDTO.Modelo,
                        Placa = veiculoDTO.Placa,
                        TipoVeiculo = (TipoVeiculoEnum)veiculoDTO.TipoVeiculo,
                    };

                    if (veiculo.TipoVeiculo == TipoVeiculoEnum.Carro)
                    {
                        if (veiculoDTO.Carro == null)
                            return BadRequest("É necessário informar as informacoes do Carro");

                        veiculo.Carro = new Carro { CapacidadePassageiro = veiculoDTO.Carro.CapacidadePassageiro };
                        veiculo.Caminhao = null;
                    }
                    else
                    {
                        if (veiculoDTO.Caminhao == null)
                            return BadRequest("É necessário informar as informacoes do Caminhão");

                        veiculo.Caminhao = new Caminhao { CapacidadeDeCarga = veiculoDTO.Caminhao.CapacidadeCarga };
                        veiculo.Carro = null;
                    }

                    return Ok(await _veiculoService.Salvar(veiculo));
                }
                else
                    return BadRequest("O Valor nao pode ser null");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<bool> RemoverVeiculo(int codigoVeiculo)
        {
            try
            {
                return await _veiculoService.RemoverVeiculo(codigoVeiculo);
            }
            catch
            {
                return false;
            }
        }
    }
}

