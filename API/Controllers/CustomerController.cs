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
        public ActionResult Get([FromQuery] Guid customerRef)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
