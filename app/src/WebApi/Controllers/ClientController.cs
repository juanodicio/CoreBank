using Application;
using Application.Client.Commands.CreateClient;
using Domain;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model.Client;

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