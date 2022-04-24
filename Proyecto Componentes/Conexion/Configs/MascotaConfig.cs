﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pojos;


namespace Datos.Configs
{
    public class MascotaConfig : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {

            builder.ToTable("Mascotas");
            builder.HasKey(c => c._id);
            builder.HasAlternateKey(mascota => mascota.nombre);



        }
    }
}
