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
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    DescripcionMenu = table.Column<string>(nullable: true),
                    RutaUrlMenu = table.Column<string>(nullable: true),
                    OrdenamientoMenu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Natilleras",
                columns: table => new
                {
                    NatilleraId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
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
                    TipoDocumentoId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentos", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    FechaExpiraToken = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenId);
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
                name: "MenuSubMenu",
                columns: table => new
                {
                    SubMenuId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    DescripcionSubMenu = table.Column<string>(nullable: true),
                    RutaUrlSubMenu = table.Column<string>(nullable: true),
                    OrdenamientoSubMenu = table.Column<int>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSubMenu", x => x.SubMenuId);
                    table.ForeignKey(
                        name: "FK_MenuSubMenu_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    SocioId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
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
                    TipoDocumentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.SocioId);
                    table.ForeignKey(
                        name: "FK_Socios_TiposDocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TiposDocumentos",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermisos",
                columns: table => new
                {
                    MenuPermisoId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    AspNetRolesId = table.Column<string>(type: "NVARCHAR(128)", nullable: true),
                    SubMenuId = table.Column<Guid>(nullable: true),
                    Crear = table.Column<bool>(nullable: false),
                    Borrar = table.Column<bool>(nullable: false),
                    Actualizar = table.Column<bool>(nullable: false),
                    Ver = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermisos", x => x.MenuPermisoId);
                    table.ForeignKey(
                        name: "FK_MenuPermisos_MenuSubMenu_SubMenuId",
                        column: x => x.SubMenuId,
                        principalTable: "MenuSubMenu",
                        principalColumn: "SubMenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesRecaudos",
                columns: table => new
                {
                    ActividadRecaudoId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NatillerasNatilleraId = table.Column<Guid>(nullable: true),
                    SociosSocioId = table.Column<Guid>(nullable: true),
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
                    SocioId = table.Column<Guid>(nullable: false),
                    SociosSocioId = table.Column<Guid>(nullable: true)
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
                    CuotaSocioId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SocioId = table.Column<Guid>(nullable: false),
                    FechaPagoCuota = table.Column<DateTime>(nullable: false),
                    ValorCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotalCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasSocios", x => x.CuotaSocioId);
                    table.ForeignKey(
                        name: "FK_CuotasSocios_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NatilleraSocios",
                columns: table => new
                {
                    NatilleraSocioId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NatilleraId = table.Column<Guid>(nullable: false),
                    SocioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatilleraSocios", x => x.NatilleraSocioId);
                    table.ForeignKey(
                        name: "FK_NatilleraSocios_Natilleras_NatilleraId",
                        column: x => x.NatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NatilleraSocios_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SocioId = table.Column<Guid>(nullable: false),
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
                        name: "FK_Prestamos_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Cascade);
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
                    CuotaPrestamoId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RowCreated = table.Column<DateTime>(nullable: false),
                    RowUpdated = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PrestamoId = table.Column<Guid>(nullable: false),
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
                        name: "FK_CuotasPrestamos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38e606c8-7f9e-4158-a671-444992bd89f5", "7a4b368f-4ad9-4dc8-abec-72ea4cf36db0", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SocioId", "SociosSocioId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38e606c8-7f9e-4158-a671-444992bd89f5", 0, "52de73a0-39c6-42fa-a5c5-4da232483486", "dun34@hotmail.com", true, false, null, "DUN34@HOTMAIL.COM", "DUN34@HOTMAIL.COM", "AQAAAAEAACcQAAAAECokRB0Ykqax/BA+NyuGbiauAJ+X4Mcs1STYMpREdRcWXSLFDxcEtrLpGczPaZX6bw==", null, false, "DVJF5PLZA76QHHTNVSJYRF5NVCQTSRTQ", new Guid("f95ba36f-daa0-4b14-a142-51ec51cf7d91"), null, false, "dun34@hotmail.com" });

            migrationBuilder.InsertData(
                table: "TiposDocumentos",
                columns: new[] { "TipoDocumentoId", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("ceb36362-6ebb-4649-ae51-48ee9f60892a"), "Cédula" },
                    { new Guid("ba4b88fb-6ac5-4678-8de6-95925728dc67"), "Tarjeta de Identidad" },
                    { new Guid("1e424d0f-622a-4ba4-9d11-aef931d89239"), "Pasaporte" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "38e606c8-7f9e-4158-a671-444992bd89f5", "38e606c8-7f9e-4158-a671-444992bd89f5" });

            migrationBuilder.InsertData(
                table: "Socios",
                columns: new[] { "SocioId", "Celular", "Direccion", "Email", "FechaNacimiento", "Nombres", "NumeroDocumento", "PrimerApellidos", "RowCreated", "RowUpdated", "SegundoApellidos", "Telefono", "TipoDocumentoId" },
                values: new object[] { new Guid("f95ba36f-daa0-4b14-a142-51ec51cf7d91"), "3112343434", "Dirección", "dun34@hotmail.com", new DateTime(1990, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darwin", "11803053", "Urrutia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 26, 5, 40, 28, 469, DateTimeKind.Local).AddTicks(2266), "mosquera", "2343434", new Guid("ceb36362-6ebb-4649-ae51-48ee9f60892a") });

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
                name: "IX_CuotasPrestamos_PrestamoId",
                table: "CuotasPrestamos",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasSocios_SocioId",
                table: "CuotasSocios",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermisos_SubMenuId",
                table: "MenuPermisos",
                column: "SubMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubMenu_MenuId",
                table: "MenuSubMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_NatilleraSocios_NatilleraId",
                table: "NatilleraSocios",
                column: "NatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_NatilleraSocios_SocioId",
                table: "NatilleraSocios",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_SocioId",
                table: "Prestamos",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_TipoDocumentoId",
                table: "Socios",
                column: "TipoDocumentoId");
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
                name: "MenuPermisos");

            migrationBuilder.DropTable(
                name: "NatilleraSocios");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "MenuSubMenu");

            migrationBuilder.DropTable(
                name: "Natilleras");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");
        }
    }
}
