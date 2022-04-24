using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pojos;


namespace Datos.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuarios");
            builder.HasKey(c => c._id);
            builder.HasAlternateKey(usuario => usuario.nombre);



        }
    }
}
