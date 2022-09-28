using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Entities;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _context.Products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            var update_pro = _context.Products.Where(update_pro => update_pro.Id == id).FirstOrDefault();
            if (update_pro == null)
            {
                return NotFound();
            }
            update_pro.Name = product.Name;
            update_pro.Code = product.Code;
            update_pro.Price = product.Price;
            // _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var product = await _context.Products.FindAsync(id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
