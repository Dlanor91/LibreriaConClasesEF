// <auto-generated />
using System;
using Libreria.AccesoDatos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Libreria.AccesoDatos.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20220617001643_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Libreria.Dominio.EntidadesNegocio.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Libreria.Dominio.EntidadesNegocio.AutorPublicacion", b =>
                {
                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("PublicacionId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AutorId", "PublicacionId");

                    b.HasIndex("PublicacionId");

                    b.ToTable("AutorPublicacion");
                });

            modelBuilder.Entity("Libreria.Dominio.EntidadesNegocio.Publicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadPaginas")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPublicado")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrecioSugerido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Publicaciones");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Publicacion");
                });

            modelBuilder.Entity("Libreria.Dominio.EntidadesNegocio.Libro", b =>
                {
                    b.HasBaseType("Libreria.Dominio.EntidadesNegocio.Publicacion");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ISBN")
                        .IsUnique()
                        .HasFilter("[ISBN] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Libro");
                });

            modelBuilder.Entity("Libreria.Dominio.EntidadesNegocio.Revista", b =>
                {
                    b.HasBaseType("Libreria.Dominio.EntidadesNegocio.Publicacion");

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("TablaContenido")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Revista");
                });

            modelBuilder.Entity("Libreria.Dominio.EntidadesNegocio.AutorPublicacion", b =>
                {
                    b.HasOne("Libreria.Dominio.EntidadesNegocio.Autor", "Autor")
                        .WithMany("AutoresPublicaciones")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libreria.Dominio.EntidadesNegocio.Publicacion", "Publicacion")
                        .WithMany("AutoresPublicaciones")
                        .HasForeignKey("PublicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
