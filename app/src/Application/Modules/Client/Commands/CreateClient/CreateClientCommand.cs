using Application.Persistence;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Modules.Client.Commands.CreateClient
{
    public class CreateClientCommand: IRequest<CreateClientResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateClientHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
    {
        private readonly AppDbContext _context;

        public CreateClientHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Domain.Client()
            {
                Id = new Guid(), FirstName = request.FirstName, LastName = request.LastName
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);
            
            var response =  new CreateClientResponse()
            {
                Id = client.Id, FirstName = client.FirstName, LastName = client.LastName, CreatedAt = client.CreatedAt, UpdatedAt = client.UpdatedAt
            };

            return response;
        }
    }

    public class CreateClientResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}