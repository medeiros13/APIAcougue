using APIAcougue.Data;
using APIAcougue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAcougue.Controllers
{
    [Route("v1/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public SalesController(AppDbContext db)
        {
            _db = db;
        }


        // GET: api/<SalesController>
        [HttpGet]
        [Produces(typeof(List<Sale>))]
        public async Task<IResult> GetAll()
        {
            var sales = await _db.Sales.ToListAsync();

            if (sales == null || !sales.Any())
                return Results.NotFound();

            return Results.Ok(sales);
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        [Produces(typeof(Sale))]
        public async Task<IResult> GetById(int id)
        {
            var sale = await _db.Sales.SingleOrDefaultAsync(x => x.Id == id);
            if (sale == null)
                return Results.NotFound(id);

            return Results.Ok(sale);
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] Sale sale)
        {
            await _db.Sales.AddAsync(sale);
            await _db.SaveChangesAsync();

            return Results.Created($"{Url}{sale.Id}", sale);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] Sale inputSale)
        {
            var sale = await _db.Sales.SingleOrDefaultAsync(x => x.Id == id);

            if (sale is null)
                return Results.NotFound(id);

            sale.Customer = inputSale.Customer;
            sale.Items = inputSale.Items;

            await _db.SaveChangesAsync();

            return Results.NoContent();
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            var sale = await _db.Sales.SingleOrDefaultAsync(x => x.Id == id);

            if (sale == null)
                return Results.NotFound(id);

            _db.Sales.Remove(sale);
            await _db.SaveChangesAsync();

            return Results.Ok(sale);
        }
    }
}
