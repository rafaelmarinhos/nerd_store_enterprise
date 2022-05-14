using NSE.Core.Data;

namespace NSE.Customers.API.Models.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add(Customer customer);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetBySocialNumber(string socialNumber);
        void AddAddress(Address address);
        Task<Address> GetAddressById(Guid id);
    }
}
