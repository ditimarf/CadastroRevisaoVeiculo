using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>
    {
        private readonly AppDBContext _context;
        public VeiculoRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Veiculo> ObterTodos(string Filtro)
        {
            //Nao é o mais correto fazer esse 'Ano.ToString()' já que ele ira fazer um convert para toda a base. Fica um TODO para melhorar
            return _context.Veiculo
                .Where(x =>
                    x.Placa.Contains(Filtro) ||
                    x.Modelo.Contains(Filtro) ||
                    x.Ano.ToString().Contains(Filtro) ||
                    x.Cor.Contains(Filtro))
                .Include(x => x.Carro)
                .Include(x => x.Caminhao)
                .Include(x => x.Revisoes)
                .AsNoTracking();
        }

        //remove em cascata, removendo tambem todas as tabelas ligadas
        public override async Task<bool> Remover(int codigo)
        {
            var veiculo = await _context.Veiculo.FindAsync(codigo);
            if (veiculo != null)
            {   //Remove os relacionamentos (Carro, Caminhao e Revisoes)
                _context.Veiculo.Remove(veiculo);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}

