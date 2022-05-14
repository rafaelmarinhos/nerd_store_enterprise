using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Customers.API.Models;
using NSE.Customers.API.Models.Repositories;

namespace NSE.Customers.API.Application.Commands
{
    public class CustomerCommandHandler : CommandHandler, IRequestHandler<NewCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(NewCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var customer = new Customer(
                request.Id, request.Name, request.Email, request.SocialNumber);

            var customerExist = await _customerRepository.GetBySocialNumber(customer.SocialNumber);

            if (customerExist != null)
            {
                AddError("Already has this social number.");
                return ValidationResult;
            }

            _customerRepository.Add(customer);

            return await PersistData(_customerRepository.UnitOfWork);
        }
    }
}
