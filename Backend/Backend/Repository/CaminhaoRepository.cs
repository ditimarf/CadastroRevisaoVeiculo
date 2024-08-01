using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CaminhaoRepository : BaseRepository<Caminhao>
	{
        private readonly AppDBContext _context;
        public CaminhaoRepository(AppDBContext context) : base(context)
		{
			_context = context;
		}

        //public override IEnumerable<Caminhao> ObterTodos()
        //{
        //    return _context.Caminhao.Include(x => x.Veiculo).AsNoTracking();
        //}
    }
}

