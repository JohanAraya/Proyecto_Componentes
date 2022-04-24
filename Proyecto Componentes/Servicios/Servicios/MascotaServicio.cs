using Pojos;
using Pojos.Interfaces.Repositorios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class MascotaServicio : IServicioBase<Mascota, Guid>
    {

        private readonly IRepositorioBase<Mascota, Guid> repoMascota;

        public MascotaServicio(IRepositorioBase<Mascota, Guid> _repoMascota)
        {
            repoMascota = _repoMascota;
        }
        public Mascota Agregar(Mascota entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException("La mascota es requerida");
            }

            var resultMascota = repoMascota.Agregar(entidad);
            repoMascota.guardarTodosLosCambios();
            return resultMascota;
        }

        public void Editar(Mascota tentidad)
        {
            if (tentidad == null)
            {
                throw new ArgumentNullException("La mascota es requerida para editar");
            }

            repoMascota.Editar(tentidad);
            repoMascota.guardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoMascota.Eliminar(entidadId);
            repoMascota.guardarTodosLosCambios();
        }

        public List<Mascota> Listar()
        {
            return repoMascota.Listar();
        }

        public Mascota seleccionarPorId(Guid entidadId)
        {
            return repoMascota.seleccionarPorId(entidadId);
        }

        //public Mascota seleccionarPorIdUsuario(string idUsuario)
        //{
        //    return repoMascota.seleccionarPorIdUsuario(idUsuario);
        //}
    }
}
