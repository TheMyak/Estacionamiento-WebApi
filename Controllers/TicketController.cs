using Estacionamiento_WebApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento_WebApi.Controllers
{
    [ApiController]
    [Route("ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TicketController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ticket ticket)
        {
            dbContext.Add(ticket);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            return await dbContext.Ticket.FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<List<Ticket>>> GetAll()
        {
            return await dbContext.Ticket.Include(x => x.estacionamiento).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Ticket ticket, int id)
        {
            if (ticket.ID != id)
            {
                return BadRequest("El ID del ticket no coincide con la base de datos.");
            }
            dbContext.Update(ticket);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Ticket.AnyAsync(x => x.ID == id);
            if (!exist)
            {
                return NotFound("El ID ingresado no se encuentra en la base de datos.");
            }
            dbContext.Remove(new Ticket()
            { ID = id, }
            );
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
