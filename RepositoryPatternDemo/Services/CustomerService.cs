using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RepositoryPatternDemo.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IGenericRepository<Customer> _repository;
        public CustomerService(IGenericRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _repository.AddAsync(customer);
            await _repository.SaveAsync();
            return customer;
        }
        public async Task<bool> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _repository.GetByIdAsync(id);
            if (existingCustomer == null)
                return false;
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            await _repository.UpdateAsync(existingCustomer);
            await _repository.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existingCustomer = await _repository.GetByIdAsync(id);
            if (existingCustomer == null)
                return false;
            await _repository.DeleteAsync(existingCustomer);
            await _repository.SaveAsync();
            return true;
        }
    }
}
