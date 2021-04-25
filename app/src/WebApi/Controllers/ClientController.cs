using Application.Modules.Client.Commands.CreateClient;
using Application.Persistence;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public ClientController(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<Client> Index()
        {
            return _context.Clients.AsQueryable();
        }

        [HttpPost]
        public async Task<CreateClientResponse> CreateClient(CreateClientCommand client)
        {
            var ret = await _mediator.Send(client);
            return ret;
        }
    }
}