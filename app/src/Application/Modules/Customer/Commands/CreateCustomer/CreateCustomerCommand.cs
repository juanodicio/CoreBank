using Application.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Modules.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<CreateCustomerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly AppDbContext _context;

        public CreateCustomerHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer()
            {
                Id = new Guid(), FirstName = request.FirstName, LastName = request.LastName
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);
            
            var response =  new CreateCustomerResponse()
            {
                Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, CreatedAt = customer.CreatedAt, UpdatedAt = customer.UpdatedAt
            };

            return response;
        }
    }

    public class CreateCustomerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}