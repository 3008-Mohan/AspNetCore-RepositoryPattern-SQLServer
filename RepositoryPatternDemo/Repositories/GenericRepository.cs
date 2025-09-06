using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Data;
using RepositoryPatternDemo.Models;
namespace RepositoryPatternDemo.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
