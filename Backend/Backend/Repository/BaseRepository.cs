using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public abstract class BaseRepository<T> where T : class
        {
            private readonly AppDBContext _context;
            public BaseRepository(AppDBContext context)
            {
                _context = context;
            }

            public virtual async Task<T?> Obter(int id)
            {
                return await _context.Set<T>().FindAsync(id);
            }

            public virtual IEnumerable<T> ObterTodos()
            {
                return _context.Set<T>().AsNoTracking();
            }

            public virtual async Task<T> Inserir(T objeto)
            {
                _context.Set<T>().Add(objeto);
                await _context.SaveChangesAsync();
                return objeto;
            }

            public virtual async Task Remover(T objeto)
            {
                _context.Set<T>().Remove(objeto);
                await _context.SaveChangesAsync();
            }

        public virtual async Task<bool> Remover(int codigo)
        {
            var objeto = await Obter(codigo);
            if (objeto != null)
            {
                _context.Set<T>().Remove(objeto);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public virtual async Task<T> Atualizar(T objetoNovo, int key)
            {
                var objetoAntigo = await _context.Set<T>().FindAsync(key);
                if (objetoAntigo != null)
                {
                    _context.Entry(objetoAntigo).CurrentValues.SetValues(objetoNovo);
                    await _context.SaveChangesAsync();
                }
                return objetoNovo;
            }
        }
}

