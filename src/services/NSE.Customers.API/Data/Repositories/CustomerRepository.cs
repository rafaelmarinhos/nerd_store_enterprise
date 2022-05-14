using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Customers.API.Models;
using NSE.Customers.API.Models.Repositories;

namespace NSE.Customers.API.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Address> GetAddressById(Guid id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(e => e.CustomerId == id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetBySocialNumber(string socialNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.SocialNumber == socialNumber);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
        }        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
