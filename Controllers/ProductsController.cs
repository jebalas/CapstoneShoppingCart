using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapstoneWk4ShoppingList.Context;
using CapstoneWk4ShoppingList.Models;

namespace CapstoneWk4ShoppingList.Controllers
{
  
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;
        private ShoppingCartModel _shoppingCartModel; 

        public ProductsController(InventoryContext context, ShoppingCartModel shoppingCartModel)
        {
            _context = context;
            _shoppingCartModel = shoppingCartModel;
        }

       
        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShoppingCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _shoppingCartModel.ShoppingList.Add(product);
            _shoppingCartModel.Total += product.Price;
            return View(_shoppingCartModel);
        }

        //[HttpPost]
        public IActionResult Checkout()
        {
            var model = new CheckoutModel();
            model.ShoppingList = _shoppingCartModel.ShoppingList;
            model.Total = _shoppingCartModel.Total;
            model.Tax = Decimal.Multiply(model.Total, (decimal)0.06);
            model.GrandTotal = Decimal.Add(model.Total, model.Tax);
            return View(model);
        }

        // GET: api/Products/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Products>> GetProducts(int id)
        // {
        ///     var products = await _context.Products.FindAsync(id);
        //
        //     if (products == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return products;
        // }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
