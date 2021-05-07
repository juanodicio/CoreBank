using Application.Modules.Customer.Commands.CreateCustomer;
using Application.Persistence;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CustomerController(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<Customer> Index()
        {
            return _context.Customers.AsQueryable();
        }

        [HttpPost]
        public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerCommand customer)
        {
            var ret = await _mediator.Send(customer);
            return ret;
        }
    }
}