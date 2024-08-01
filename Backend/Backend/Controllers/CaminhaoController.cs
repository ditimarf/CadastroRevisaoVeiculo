using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class CaminhaoController : BaseController
    {
        private readonly CaminhaoService _caminhaoService;

        public CaminhaoController(CaminhaoService caminhaoService)
        {
            _caminhaoService = caminhaoService;
        }

        [HttpGet]
        public IEnumerable<Caminhao> Index()
        {
            return _caminhaoService.ObterTodosOsVeiculos();
        }

        //[HttpPost]
        //public async Task<Caminhao> Salvar(CaminhaoDTO caminhaoDTO)
        //{
        //    var caminhao = new Caminhao
        //    {
        //        CapacidadeDeCarga = caminhaoDTO.CapacidadeCarga,
        //        Veiculo = new Veiculo
        //        {
        //            Ano = caminhaoDTO.Ano,
        //            Cor = caminhaoDTO.Cor,
        //            Modelo = caminhaoDTO.Modelo,
        //            Placa = caminhaoDTO.Placa,
        //            TipoVeiculo = Enums.TipoVeiculoEnum.Caminhao
        //        }
        //    };

        //    return await _caminhaoService.Salvar(caminhao);
        //}
    }
}

