using System;
using Backend.Models;
using Backend.Repository;

namespace Backend.Services
{
	public class CaminhaoService
	{
        private readonly CaminhaoRepository _caminhaoRepository;
        public CaminhaoService(CaminhaoRepository caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }

        //public IEnumerable<Caminhao> ObterTodosOsVeiculos()
        //{
        //    return _caminhaoRepository.ObterTodos();
        //}

        //public async Task<Caminhao> Salvar(Caminhao caminhao)
        //{
        //    if (caminhao == null)
        //        throw new InvalidDataException("Voce nõ pode inserir um valor null");
        //    else
        //        return await _caminhaoRepository.Inserir(caminhao);
        //}
    }
}

