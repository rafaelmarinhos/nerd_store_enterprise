using NSE.Core.DomainObject;
using NSE.Core.DomainObject.ValueObjects;

namespace NSE.Customers.API.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string SocialNumber { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }

        // EF Relation
        protected Customer() { }

        public Customer(Guid id, string name, string email, string socialNumber)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            SocialNumber = socialNumber;
            Active = false;
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }
    }
}
