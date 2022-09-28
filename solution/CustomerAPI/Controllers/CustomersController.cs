using CustomerAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CustomersController : ControllerBase
    {

        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _context.Customers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Customer customer)
        {
            var update_cus = _context.Customers.Where(update_cus => update_cus.Id == id).FirstOrDefault();
            if (update_cus == null)
            {
                return NotFound();
            }
            update_cus.Name = customer.Name;
            update_cus.MobiNumber = customer.MobiNumber;
            update_cus.Email = customer.Email;
            // _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
            return Ok();


        }
    }
}

