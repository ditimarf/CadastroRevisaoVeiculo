using Backend.Models;
using Backend.Repository;

namespace Backend.Services
{
    public class CarroService
	{
		private readonly CarroRepository _carroRepository;
		public CarroService(CarroRepository carroRepository)
		{
			_carroRepository = carroRepository;
		}

		//public IEnumerable<Carro> ObterTodosOsVeiculos()
		//{
		//	return _carroRepository.ObterTodos();
		//}

		//public async Task<Carro> Salvar(Carro carro)
		//{
		//	if (carro == null)
		//		throw new InvalidDataException("Voce nõ pode inserir um valor null");
		//	else
		//		return await _carroRepository.Inserir(carro);
		//}
	}
}

