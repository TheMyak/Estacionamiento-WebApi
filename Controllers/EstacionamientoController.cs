using Microsoft.AspNetCore.Mvc;
using Estacionamiento_WebApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento_WebApi.Controllers
{
    [ApiController]
    [Route("estacionamiento")]
    public class EstacionamientoController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EstacionamientoController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public ActionResult<List<Estacionamiento>> get()
        {
            return new List<Estacionamiento>()
            {
                new Estacionamiento() { ID= 1, Nombre= "Lugar A1"},
                new Estacionamiento() { ID= 2, Nombre= "Lugar A2"}
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estacionamiento estacionamiento)
        {
            var existeTicket = await dbContext.Ticket.AnyAsync(x => x.ID == estacionamiento.TicketID);
            if (!existeTicket)
            {
                return BadRequest("No existe el ticket.");
            }
            dbContext.Add(estacionamiento);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<List<Estacionamiento>>> GetAll()
        {
            return await dbContext.Estacionamiento.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Estacionamiento estacionamiento, int id)
        {
            if (estacionamiento.ID != id)
            {
                return BadRequest("El ID del estacionamiento no coincide con la base de datos.");
            }
            var existeTicket = await dbContext.Ticket.AnyAsync(x => x.ID == estacionamiento.TicketID);
            if (!existeTicket)
            {
                return BadRequest("No existe el ticket.");
            }
            dbContext.Update(estacionamiento);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Estacionamiento.AnyAsync(x => x.ID == id);
            if (!exist)
            {
                return NotFound("El ID ingresado no se encuentra en la base de datos.");
            }
            dbContext.Remove(new Estacionamiento()
                { ID = id, }
            );
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}