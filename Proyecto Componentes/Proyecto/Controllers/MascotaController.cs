using Datos.Contextos;
using Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Pojos;
using Servicios.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCosmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        MascotaServicio CrearServicio()
        {
            Conexion db = new Conexion();
            MascotaRepositorio repo = new MascotaRepositorio(db);
            MascotaServicio servicio = new MascotaServicio(repo);
            return servicio;
        }
        // GET: api/<MascotaController>
        [HttpGet]
        public ActionResult<List<Mascota>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<MascotaController>/5
        [HttpGet("{id}")]
        public ActionResult<Mascota> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.seleccionarPorId(id));
        }

        // POST api/<MascotaController>
        [HttpPost]
        public ActionResult Post([FromBody] Mascota mascota)
        {
            var servicio = CrearServicio();
            servicio.Agregar(mascota);
            return Ok("Agregada Satisfactoriamente");
        }

        // PUT api/<MascotaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Mascota mascota)
        {
            var servicio = CrearServicio();
            mascota._id = id;
            servicio.Editar(mascota);
            return Ok("Editado correctamennte");

        }

        // DELETE api/<MascotaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente");

        }
    }
}
