﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Natillera.DataAccess;

namespace Natillera.DataAccess.Migrations
{
    [DbContext(typeof(NatilleraDBContext))]
    partial class NatilleraDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Natillera.DataAccess.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.ActividadesRecaudos", b =>
                {
                    b.Property<int>("ActividadRecaudoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionActividad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRealizaActividad")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NatillerasNatilleraId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("SociosSocioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorInvertido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorNetoGanancia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorRecaudado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ActividadRecaudoId");

                    b.HasIndex("NatillerasNatilleraId");

                    b.HasIndex("SociosSocioId");

                    b.ToTable("ActividadesRecaudos");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.CuotasPrestamos", b =>
                {
                    b.Property<int>("CuotaPrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiasMora")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEsperaPago")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaLimitePago")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PrestamosPrestamoId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("ValorCuota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorDiasMora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorInteres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorNetoPagoCuota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CuotaPrestamoId");

                    b.HasIndex("PrestamosPrestamoId");

                    b.ToTable("CuotasPrestamos");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.CuotasSocios", b =>
                {
                    b.Property<int>("CuotaSocioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaPagoCuota")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NatillerasNatilleraId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("SociosSocioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCuota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorMulta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotalCuota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CuotaSocioId");

                    b.HasIndex("NatillerasNatilleraId");

                    b.HasIndex("SociosSocioId");

                    b.ToTable("CuotasSocios");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.NatilleraSocios", b =>
                {
                    b.Property<int>("NatilleraSocioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NatillerasNatilleraId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("SociosSocioId")
                        .HasColumnType("int");

                    b.HasKey("NatilleraSocioId");

                    b.HasIndex("NatillerasNatilleraId");

                    b.HasIndex("SociosSocioId");

                    b.ToTable("NatilleraSocios");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.Natilleras", b =>
                {
                    b.Property<int>("NatilleraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiasGraciaMora")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInicioPagoCuota")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroCuotas")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TipoPago")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCuotaPagar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("ValorMoraDiaFijo")
                        .HasColumnType("bit");

                    b.Property<decimal>("ValorMoraPagar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NatilleraId");

                    b.ToTable("Natilleras");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaDesembolso")
                        .HasColumnType("datetime2");

                    b.Property<int>("PorcentajeInteres")
                        .HasColumnType("int");

                    b.Property<string>("ResponsablePagoPrestamo")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("SociosSocioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCuotasNatillaActual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPrestado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PrestamoId");

                    b.HasIndex("SociosSocioId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.Socios", b =>
                {
                    b.Property<int>("SocioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("TiposDocumentosTipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("SocioId");

                    b.HasIndex("TiposDocumentosTipoDocumentoId");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.TiposDocumentos", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TiposDocumentos");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.Usuarios", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Natillera.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Natillera.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Natillera.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Natillera.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.ActividadesRecaudos", b =>
                {
                    b.HasOne("Natillera.DataAccessContract.Entidades.Natilleras", "Natilleras")
                        .WithMany()
                        .HasForeignKey("NatillerasNatilleraId");

                    b.HasOne("Natillera.DataAccessContract.Entidades.Socios", "Socios")
                        .WithMany()
                        .HasForeignKey("SociosSocioId");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.CuotasPrestamos", b =>
                {
                    b.HasOne("Natillera.DataAccessContract.Entidades.Prestamos", "Prestamos")
                        .WithMany("CuotasPrestamos")
                        .HasForeignKey("PrestamosPrestamoId");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.CuotasSocios", b =>
                {
                    b.HasOne("Natillera.DataAccessContract.Entidades.Natilleras", "Natilleras")
                        .WithMany("CuotasSocios")
                        .HasForeignKey("NatillerasNatilleraId");

                    b.HasOne("Natillera.DataAccessContract.Entidades.Socios", "Socios")
                        .WithMany()
                        .HasForeignKey("SociosSocioId");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.NatilleraSocios", b =>
                {
                    b.HasOne("Natillera.DataAccessContract.Entidades.Natilleras", "Natilleras")
                        .WithMany("NatilleraSocios")
                        .HasForeignKey("NatillerasNatilleraId");

                    b.HasOne("Natillera.DataAccessContract.Entidades.Socios", "Socios")
                        .WithMany("NatilleraSocios")
                        .HasForeignKey("SociosSocioId");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.Prestamos", b =>
                {
                    b.HasOne("Natillera.DataAccessContract.Entidades.Socios", "Socios")
                        .WithMany()
                        .HasForeignKey("SociosSocioId");
                });

            modelBuilder.Entity("Natillera.DataAccessContract.Entidades.Socios", b =>
                {
                    b.HasOne("Natillera.DataAccessContract.Entidades.TiposDocumentos", "TiposDocumentos")
                        .WithMany()
                        .HasForeignKey("TiposDocumentosTipoDocumentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
