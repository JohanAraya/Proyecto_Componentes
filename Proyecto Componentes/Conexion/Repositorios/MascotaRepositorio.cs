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
    public class MascotaRepositorio : IRepositorioBase<Mascota, Guid>
    {
        private Conexion db;

        public MascotaRepositorio(Conexion _db)
        {
            db = _db;
        }
        public Mascota Agregar(Mascota entidad)
        {
            entidad._id = Guid.NewGuid();
            db.Mascotas.Add(entidad);
            return entidad;
        }

        public void Editar(Mascota tentidad)
        {
            var mascotaSeleccionada = db.Mascotas.Where(c => c._id == tentidad._id).FirstOrDefault();
            if (mascotaSeleccionada != null)
            {
                mascotaSeleccionada.nombre = tentidad.nombre;
                mascotaSeleccionada.raza = tentidad.raza;
                mascotaSeleccionada.fotoUrl = tentidad.fotoUrl;
                mascotaSeleccionada.tipo = tentidad.tipo;
                mascotaSeleccionada.sexo = tentidad.sexo;
                mascotaSeleccionada.descripcion = tentidad.descripcion;
                

                db.Entry(mascotaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
        }

        public void Eliminar(Guid entidadId)
        {
            var mascotaSeleccionada = db.Mascotas.Where(c => c._id == entidadId).FirstOrDefault();
            if (mascotaSeleccionada != null)
            {
                db.Mascotas.Remove(mascotaSeleccionada);

            }
        }

        public void guardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Mascota> Listar()
        {
            return db.Mascotas.ToList();
        }

        public Mascota seleccionarPorId(Guid entidadId)
        {
            var mascotaSeleccionada = db.Mascotas.Where(c => c._id == entidadId).FirstOrDefault();
            return mascotaSeleccionada;
        }

        public Mascota seleccionarPorIdUsuario(string idUsuario)
        {
            var mascotaSeleccionada = db.Mascotas.Where(c => c.idUsuario == idUsuario).FirstOrDefault();
            return mascotaSeleccionada;
        }
    }
}
