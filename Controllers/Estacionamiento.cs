using Microsoft.AspNetCore.Mvc;
using Estacionamiento_WebApi.Entidades;

namespace Estacionamiento_WebApi.Controllers
{
    [ApiController]
    [Route("api/estacionamiento")]
    public class EstacionamientoController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Estacionamiento>> get()
        {
            return new List<Estacionamiento>()
            {
                new Estacionamiento() { ID= 1, Lugar= "Lugar A1"},
                new Estacionamiento() { ID= 2, Lugar= "Lugar A2"}
            };
        }
    }
}