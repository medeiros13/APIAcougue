using APIAcougue.Data;
using APIAcougue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAcougue.Controllers
{
    [Route("v1/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Produces(typeof(List<User>))]
        public async Task<IResult> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            if (users == null || !users.Any())
                return Results.NotFound();

            return Results.Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [Produces(typeof(User))]
        public async Task<IResult> GetById(int id)
        {
            if (id.GetType() != typeof(int))
                return Results.BadRequest();

            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return Results.NotFound(id);

            return Results.Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] User user)
        {
            if (user.GetType() != typeof(User))
                return Results.BadRequest();

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return Results.Created($"{Url}{user.Id}", user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] User inputUser)
        {
            if (id.GetType() != typeof(int) || inputUser.GetType() != typeof(User))
                return Results.BadRequest();

            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user is null)
                return Results.NotFound(id);

            user.Name = inputUser.Name;
            user.Password = inputUser.Password;

            await _db.SaveChangesAsync();

            return Results.NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            if (id.GetType() != typeof(int))
                return Results.BadRequest();

            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return Results.NotFound(id);

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return Results.Ok(user);
        }
    }
}
