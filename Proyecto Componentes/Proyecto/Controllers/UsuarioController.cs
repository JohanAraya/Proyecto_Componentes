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
    public class UsuarioController : ControllerBase
    {
        UsuarioServicio CrearServicio()
        {
            Conexion db = new Conexion();
            UsuarioRepositorio repo = new UsuarioRepositorio(db);
            UsuarioServicio servicio = new UsuarioServicio(repo);
            return servicio;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.seleccionarPorId(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            var servicio = CrearServicio();
            servicio.Agregar(usuario);
            return Ok("Agregar Satisfactoriamente");
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            var servicio = CrearServicio();
            usuario._id = id;
            servicio.Editar(usuario);
            return Ok("Editado correctamennte");

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente");

        }
    }
}
