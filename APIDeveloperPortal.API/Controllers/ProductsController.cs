using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDeveloperPortal.API.Data;
using APIDeveloperPortal.API.Models;
using APIDeveloperPortal.API.VMs;

namespace APIDeveloperPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApideveloperPortalContext _context;

        public ProductsController(ApideveloperPortalContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductVM product)
        {
            Product productToEdit = new Product() { ProductName = product.ProductName };
            var productToChange = await _context.Products.FindAsync(id);
            if(productToChange is null)
            {
                return NotFound();
            }
            productToChange.ProductName = product.ProductName;
            _context.Products.Update(productToChange);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(productToChange);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductVM vm)
        {
            if (ModelState.IsValid)
            {
                // Map the view model to your domain model or use a mapper library
                var product = new Product
                {
                    ProductName = vm.ProductName,
                    ProductServices = new List<ProductService>(), // You might need to handle services as well
                    UsersProductsBridges = vm.SelectedUserIds
                        .Select(userId => new UsersProductsBridge { UserId = userId })
                        .ToList()
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return Ok(); // Or return the created product or an appropriate response
            }

            return BadRequest(ModelState);
        }
    

        [HttpPost("Model")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            Product productToAdd = new Product() { ProductName = product.ProductName };

            _context.Products.Add(productToAdd);
            await _context.SaveChangesAsync();

            return Ok(productToAdd);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
