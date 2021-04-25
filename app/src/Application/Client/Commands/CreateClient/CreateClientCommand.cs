using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Client.Commands.CreateClient
{
    public class CreateClientCommand: IRequest<CreateClientResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateClientHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
    {
        public CreateClientHandler()
        {
        }

        public Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
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