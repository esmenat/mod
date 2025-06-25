using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVentasDeTicketsDeTrenIbarra.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TypePriceForUser",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePriceForUser", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientCodigo",
                        column: x => x.ClientCodigo,
                        principalTable: "Client",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationCodigo = table.Column<int>(type: "int", nullable: false),
                    RouteCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Ticket_Reservation_ReservationCodigo",
                        column: x => x.ReservationCodigo,
                        principalTable: "Reservation",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Route_RouteCodigo",
                        column: x => x.RouteCodigo,
                        principalTable: "Route",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketCodigo = table.Column<int>(type: "int", nullable: false),
                    TypePriceForUserCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Seat_Ticket_TicketCodigo",
                        column: x => x.TicketCodigo,
                        principalTable: "Ticket",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Seat_TypePriceForUser_TypePriceForUserCodigo",
                        column: x => x.TypePriceForUserCodigo,
                        principalTable: "TypePriceForUser",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientCodigo",
                table: "Reservation",
                column: "ClientCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TicketCodigo",
                table: "Seat",
                column: "TicketCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TypePriceForUserCodigo",
                table: "Seat",
                column: "TypePriceForUserCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ReservationCodigo",
                table: "Ticket",
                column: "ReservationCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RouteCodigo",
                table: "Ticket",
                column: "RouteCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TypePriceForUser");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
