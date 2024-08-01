using Backend.Models;
using Backend.Repository;

namespace Backend.Services
{
    public class VeiculoService
	{
        private readonly VeiculoRepository _veiculoRepository;
        public VeiculoService(VeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public IEnumerable<Veiculo> RetornarTodosOsVeiculos(string Filtro)
        {
            return _veiculoRepository.ObterTodos(Filtro);
        }

        public async Task<Veiculo> Salvar(Veiculo veiculo)
        {
            return await _veiculoRepository.Inserir(veiculo);
        }

        public async Task<bool> RemoverVeiculo(int codigoVeiculo)
        {
            return await _veiculoRepository.Remover(codigoVeiculo);
        }
    }
}

