using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class RevisaoRepository : BaseRepository<Revisao>
    {
        private readonly AppDBContext _context;
        public RevisaoRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Revisao> ObterTodosRevisoesPorVeiculo(int codigoVeiculo)
        {
            return _context.Revisao.Where(x => x.CodigoVeiculo == codigoVeiculo).AsNoTracking();
        }
    }
}

