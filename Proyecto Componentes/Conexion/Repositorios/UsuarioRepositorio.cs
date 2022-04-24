using Datos.Contextos;
using Pojos;
using Pojos.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IRepositorioBase<Usuario, Guid>
    {
        private Conexion db;

        public UsuarioRepositorio(Conexion _db)
        {
            db = _db;
        }
        public Usuario Agregar(Usuario entidad)
        {
            entidad._id = Guid.NewGuid();
            db.Usuarios.Add(entidad);
            return entidad;
        }

        public void Editar(Usuario tentidad)
        {
            var usuarioSeleccionado = db.Usuarios.Where(c => c._id == tentidad._id).FirstOrDefault();
            if (usuarioSeleccionado != null)
            {
                usuarioSeleccionado.nombre = tentidad.nombre;
                usuarioSeleccionado.apellido1 = tentidad.apellido1;
                usuarioSeleccionado.telefono = tentidad.telefono;
                usuarioSeleccionado.direccion = tentidad.direccion;
                usuarioSeleccionado.correo = tentidad.correo;
                usuarioSeleccionado.password = tentidad.password;
                usuarioSeleccionado.fotoUrl = tentidad.fotoUrl;



                db.Entry(usuarioSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
        }

        public void Eliminar(Guid entidadId)
        {
            var usuarioSeleccionado = db.Usuarios.Where(c => c._id == entidadId).FirstOrDefault();
            if (usuarioSeleccionado != null)
            {
                db.Usuarios.Remove(usuarioSeleccionado);

            }
        }

        public void guardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return db.Usuarios.ToList();
        }

        public Usuario seleccionarPorId(Guid entidadId)
        {
            var usuarioSeleccionado = db.Usuarios.Where(c => c._id == entidadId).FirstOrDefault();
            return usuarioSeleccionado;
        }
    }
}
