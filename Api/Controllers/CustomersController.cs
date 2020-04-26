using System;
using System.Threading.Tasks;
using Api.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ODataController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        [HttpGet]
        //[Route("Customers")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _customerRepository.GetCustomers();
                if (customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}