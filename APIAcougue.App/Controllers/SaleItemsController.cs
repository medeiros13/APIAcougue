using APIAcougue.Data;
using APIAcougue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAcougue.Controllers
{
    [Route("v1/SaleItems")]
    [ApiController]
    public class SaleItemsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public SaleItemsController(AppDbContext db)
        {
            _db = db;
        }



        // GET: api/<SaleItemsController>
        [HttpGet]
        [Produces(typeof(List<SaleItem>))]
        public async Task<IResult> GetAll()
        {
            var saleItems = await _db.SaleItems.ToListAsync();
            if (saleItems == null || !saleItems.Any())
                return Results.NotFound();

            return Results.Ok(saleItems);
        }

        // GET api/<SaleItemsController>/5
        [HttpGet("{id}")]
        [Produces(typeof(SaleItem))]
        public async Task<IResult> GetById(int id)
        {
            if (id.GetType() != typeof(int))
                return Results.BadRequest();

            var saleItem = await _db.SaleItems.SingleOrDefaultAsync();
            if (saleItem == null)
                return Results.NotFound(id);

            return Results.Ok(saleItem);
        }

        // POST api/<SaleItemsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] SaleItem saleItem)
        {
            if (saleItem.GetType() != typeof(SaleItem))
                return Results.BadRequest();

            await _db.SaleItems.AddAsync(saleItem);
            await _db.SaveChangesAsync();

            return Results.Created($"{Url}{saleItem.Id}", saleItem);
        }

        // PUT api/<SaleItemsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] SaleItem inputSaleItem)
        {
            if (id.GetType() != typeof(int) || inputSaleItem.GetType() != typeof(SaleItem))
                return Results.BadRequest();


            var saleItem = await _db.SaleItems.SingleOrDefaultAsync(x => x.Id == id);
            if (saleItem == null)
                return Results.NotFound(id);

            saleItem.Product = inputSaleItem.Product;
            saleItem.Quantity = inputSaleItem.Quantity;

            await _db.SaveChangesAsync();

            return Results.NoContent();
        }

        // DELETE api/<SaleItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            if (id.GetType() != typeof(int))
                return Results.BadRequest();

            var saleItem = await _db.SaleItems.SingleOrDefaultAsync(x => x.Id == id);

            if (saleItem == null)
                return Results.NotFound(id);

            _db.SaleItems.Remove(saleItem);
            await _db.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
