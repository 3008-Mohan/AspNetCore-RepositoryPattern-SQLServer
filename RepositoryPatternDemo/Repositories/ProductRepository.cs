using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Data;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products.FindAsync(id);

    public async Task AddAsync(Product product) =>
        await _context.Products.AddAsync(product);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}
