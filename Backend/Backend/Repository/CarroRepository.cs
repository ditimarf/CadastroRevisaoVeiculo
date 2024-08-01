using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CarroRepository : BaseRepository<Carro>
	{
		private readonly AppDBContext _context;
		public CarroRepository(AppDBContext context) : base(context)
		{
			_context = context;
		}

   //     public override IEnumerable<Carro> ObterTodos()
   //     {
			//return _context.Carro.Include(x => x.Veiculo).AsNoTracking();
   //     }
    }
}

