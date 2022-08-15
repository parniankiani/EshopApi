using EshopApi.Contract;
using EshopApi.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository  _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var result = new ObjectResult(_customerRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            //Request.HttpContext.Response.Headers.Add("x-count", _context.Customers.Count().ToString());
            Request.HttpContext.Response.Headers.Add("x-name", "Parnian kiani");
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (await CustomerExist(id))
            {
                var  customer = await _customerRepository.Find(id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }
        private async Task<bool> CustomerExist(int id)
        {
            return await _customerRepository.IsExists(id);
        }


        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
               await _customerRepository.Add(customer);
                return RedirectToAction("GetCustomer");

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id,[FromBody] Customer customer)
        {
            await _customerRepository.Update(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
           await _customerRepository.Remove(id);
            return Ok();
          
        }
    }
}
