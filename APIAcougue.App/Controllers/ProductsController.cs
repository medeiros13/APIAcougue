using APIAcougue.Data;
using APIAcougue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAcougue.Controllers
{
    [Route("v1/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db)
        {
            _db = db;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        [Produces(typeof(List<Product>))]
        public async Task<IResult> GetAll()
        {
            var products = await _db.Products.ToListAsync();

            if (products == null || !products.Any())
                return Results.NotFound();

            return Results.Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [Produces(typeof(Product))]
        public async Task<IResult> GetById(int id)
        {
            if (id.GetType() != typeof(int))
                return Results.BadRequest();

            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return Results.NotFound(id);

            return Results.Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] Product product)
        {
            if (product.GetType() != typeof(Product))
                return Results.BadRequest();

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return Results.Created($"{Url}{product.Id}", product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] Product inputProduct)
        {
            if (id.GetType() != typeof(int) || inputProduct.GetType() != typeof(Product))
                return Results.BadRequest();

            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (product is null)
                return Results.NotFound(id);

            product.Description = inputProduct.Description;
            product.Price = inputProduct.Price;

            await _db.SaveChangesAsync();

            return Results.NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            if (id.GetType() != typeof(int))
                return Results.BadRequest();

            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return Results.NotFound(id);

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return Results.Ok(product);
        }
    }
}
