using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Natillera.DataAccess.Migrations
{
    public partial class MyPrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Natilleras",
                columns: table => new
                {
                    NatilleraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    RowUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaInicioPagoCuota = table.Column<DateTime>(nullable: false),
                    TipoPago = table.Column<int>(nullable: false),
                    ValorCuotaPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMoraPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasGraciaMora = table.Column<int>(nullable: false),
                    ValorMoraDiaFijo = table.Column<bool>(nullable: false),
                    NumeroCuotas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natilleras", x => x.NatilleraId);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentos",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentos", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    SocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NumeroDocumento = table.Column<string>(maxLength: 20, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 200, nullable: true),
                    PrimerApellidos = table.Column<string>(maxLength: 250, nullable: true),
                    SegundoApellidos = table.Column<string>(maxLength: 250, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 250, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    TiposDocumentosTipoDocumentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.SocioId);
                    table.ForeignKey(
                        name: "FK_Socios_TiposDocumentos_TiposDocumentosTipoDocumentoId",
                        column: x => x.TiposDocumentosTipoDocumentoId,
                        principalTable: "TiposDocumentos",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesRecaudos",
                columns: table => new
                {
                    ActividadRecaudoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NatillerasNatilleraId = table.Column<int>(nullable: true),
                    SociosSocioId = table.Column<int>(nullable: true),
                    DescripcionActividad = table.Column<string>(nullable: true),
                    ValorInvertido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecaudado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorNetoGanancia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRealizaActividad = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesRecaudos", x => x.ActividadRecaudoId);
                    table.ForeignKey(
                        name: "FK_ActividadesRecaudos_Natilleras_NatillerasNatilleraId",
                        column: x => x.NatillerasNatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActividadesRecaudos_Socios_SociosSocioId",
                        column: x => x.SociosSocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    SociosSocioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Socios_SociosSocioId",
                        column: x => x.SociosSocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuotasSocios",
                columns: table => new
                {
                    CuotaSocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SociosSocioId = table.Column<int>(nullable: true),
                    FechaPagoCuota = table.Column<DateTime>(nullable: false),
                    ValorCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotalCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NatillerasNatilleraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasSocios", x => x.CuotaSocioId);
                    table.ForeignKey(
                        name: "FK_CuotasSocios_Natilleras_NatillerasNatilleraId",
                        column: x => x.NatillerasNatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuotasSocios_Socios_SociosSocioId",
                        column: x => x.SociosSocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NatilleraSocios",
                columns: table => new
                {
                    NatilleraSocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NatillerasNatilleraId = table.Column<int>(nullable: true),
                    SociosSocioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatilleraSocios", x => x.NatilleraSocioId);
                    table.ForeignKey(
                        name: "FK_NatilleraSocios_Natilleras_NatillerasNatilleraId",
                        column: x => x.NatillerasNatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NatilleraSocios_Socios_SociosSocioId",
                        column: x => x.SociosSocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SociosSocioId = table.Column<int>(nullable: true),
                    FechaDesembolso = table.Column<DateTime>(nullable: false),
                    ValorCuotasNatillaActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPrestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajeInteres = table.Column<int>(nullable: false),
                    ResponsablePagoPrestamo = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Socios_SociosSocioId",
                        column: x => x.SociosSocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotasPrestamos",
                columns: table => new
                {
                    CuotaPrestamoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PrestamosPrestamoId = table.Column<int>(nullable: true),
                    ValorCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEsperaPago = table.Column<DateTime>(nullable: false),
                    FechaLimitePago = table.Column<DateTime>(nullable: false),
                    DiasMora = table.Column<int>(nullable: false),
                    ValorDiasMora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorNetoPagoCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasPrestamos", x => x.CuotaPrestamoId);
                    table.ForeignKey(
                        name: "FK_CuotasPrestamos_Prestamos_PrestamosPrestamoId",
                        column: x => x.PrestamosPrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesRecaudos_NatillerasNatilleraId",
                table: "ActividadesRecaudos",
                column: "NatillerasNatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesRecaudos_SociosSocioId",
                table: "ActividadesRecaudos",
                column: "SociosSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SociosSocioId",
                table: "AspNetUsers",
                column: "SociosSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasPrestamos_PrestamosPrestamoId",
                table: "CuotasPrestamos",
                column: "PrestamosPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasSocios_NatillerasNatilleraId",
                table: "CuotasSocios",
                column: "NatillerasNatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasSocios_SociosSocioId",
                table: "CuotasSocios",
                column: "SociosSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_NatilleraSocios_NatillerasNatilleraId",
                table: "NatilleraSocios",
                column: "NatillerasNatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_NatilleraSocios_SociosSocioId",
                table: "NatilleraSocios",
                column: "SociosSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_SociosSocioId",
                table: "Prestamos",
                column: "SociosSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_TiposDocumentosTipoDocumentoId",
                table: "Socios",
                column: "TiposDocumentosTipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesRecaudos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CuotasPrestamos");

            migrationBuilder.DropTable(
                name: "CuotasSocios");

            migrationBuilder.DropTable(
                name: "NatilleraSocios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Natilleras");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");
        }
    }
}
