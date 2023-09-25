using API.Repositories;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] Guid customerRef, CancellationToken cancellationToken)
        {
            if (customerRef == Guid.Empty)
            {
                return BadRequest($"{nameof(customerRef)} must not be empty.");
            }

            var customer = await _customerRepository.GetAsync(customerRef, cancellationToken);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer? customer, CancellationToken cancellationToken)
        {
            if (customer == null)
            {
                return BadRequest($"{nameof(customer)} must be specified.");
            }

            await _customerRepository.AddAsync(customer, cancellationToken);
            return Ok();
        }
    }
}
