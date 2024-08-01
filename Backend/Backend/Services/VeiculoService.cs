using Backend.Models;
using Backend.Repository;

namespace Backend.Services
{
    public class VeiculoService
    {
        private readonly VeiculoRepository _veiculoRepository;
        private readonly CarroRepository _carroRepository;
        private readonly CaminhaoRepository _caminhaoRepository;

        public VeiculoService(VeiculoRepository veiculoRepository, CarroRepository carroRepository, CaminhaoRepository caminhaoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _carroRepository = carroRepository;
            _caminhaoRepository = caminhaoRepository;
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

        public async Task<Veiculo> Editar(Veiculo veiculo, int codigoVeiculo)
        {
            if (veiculo == null)
                throw new InvalidDataException("Informe os dados do Veiculo");

            var veiculoAntigo = await _veiculoRepository.ObterComDetalhes(codigoVeiculo);
            if (veiculoAntigo == null)
                throw new InvalidDataException("Veiculo nao encontrado na base");

            //Removo o antigo herdeiro e adiciono o novo
            if (veiculoAntigo.TipoVeiculo != veiculo.TipoVeiculo)
            {
                if (veiculoAntigo.Carro != null)
                    await _carroRepository.Remover(veiculoAntigo.Carro);
                if (veiculoAntigo.Caminhao != null)
                    await _caminhaoRepository.Remover(veiculoAntigo.Caminhao);

                //Nao foi feita validacao se o herdeiro esta nulo porque na controller foi verificada
                //Em caso de novas regras, adicionar aqui a validacao para garantir a consistencia do BD
                if (veiculo.TipoVeiculo == Enums.TipoVeiculoEnum.Carro)
                {
                    veiculo.Carro!.CodigoVeiculo = codigoVeiculo;
                    await _carroRepository.Inserir(veiculo.Carro!);
                }
                else
                {
                    veiculo.Caminhao!.CodigoVeiculo = codigoVeiculo;
                    await _caminhaoRepository.Inserir(veiculo.Caminhao!);
                }
            }
            else //atualizo o herdeiro para os novos valores
            {
                if (veiculo.TipoVeiculo == Enums.TipoVeiculoEnum.Carro)
                {
                    veiculoAntigo.Carro!.CapacidadePassageiro = veiculo.Carro!.CapacidadePassageiro;
                    await _carroRepository.Atualizar(veiculoAntigo.Carro!, veiculoAntigo.Carro!.Codigo);
                }
                else
                {
                    veiculoAntigo.Caminhao!.CapacidadeDeCarga = veiculo.Caminhao!.CapacidadeDeCarga;
                    await _caminhaoRepository.Atualizar(veiculoAntigo.Caminhao!, veiculoAntigo.Caminhao!.Codigo);
                }
            }

            await _veiculoRepository.Atualizar(veiculo, codigoVeiculo);
            return (await _veiculoRepository.ObterComDetalhes(codigoVeiculo))!;
        }
    }
}

