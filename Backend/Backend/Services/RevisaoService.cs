using Backend.Models;
using Backend.Repository;

namespace Backend.Services
{
    public class RevisaoService
	{
        private readonly RevisaoRepository _revisaoRepository;
        public RevisaoService(RevisaoRepository revisaoRepository)
        {
            _revisaoRepository = revisaoRepository;
        }

        public IEnumerable<Revisao> ObterTodasAsRevisoesPorVeiculo(int codigoVeiculo)
        {
            return _revisaoRepository.ObterTodosRevisoesPorVeiculo(codigoVeiculo);
        }

        public async Task<bool> RemoverRegistroRevisao(int codigoRevisao)
        {
            return await _revisaoRepository.Remover(codigoRevisao);
        }

        public async Task<Revisao> InserirRevisao(Revisao revisao)
        {
            return await _revisaoRepository.Inserir(revisao);
        }
    }
}

