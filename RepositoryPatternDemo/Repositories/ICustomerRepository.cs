using RepositoryPatternDemo.Models;
namespace RepositoryPatternDemo.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task SaveAsync();
    }
}
