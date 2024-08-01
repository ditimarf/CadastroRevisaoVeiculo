using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class CarroController : BaseController
    {
        private readonly CarroService _carroService;

        public CarroController(CarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public IEnumerable<Carro> Index()
        {
            return _carroService.ObterTodosOsVeiculos();
        }

        //[HttpPost]
        //public async Task<IActionResult> Salvar(CarroDTO carroDTO)
        //{
        //    if (carroDTO != null)
        //    {
        //        var carro = new Carro
        //        {
        //            CapacidadePassageiro = carroDTO.CapacidadePassageiro,
        //            Veiculo = new Veiculo
        //            {
        //                Ano = carroDTO.Ano,
        //                Cor = carroDTO.Cor,
        //                Modelo = carroDTO.Modelo,
        //                Placa = carroDTO.Placa,
        //                TipoVeiculo = Enums.TipoVeiculoEnum.Carro
        //            }
        //        };

        //        return Ok(await _carroService.Salvar(carro));
        //    }
        //    else
        //        return BadRequest("O Valor nao pode ser null");
        //}
    }
}

