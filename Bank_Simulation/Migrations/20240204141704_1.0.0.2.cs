using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Simulation.Migrations
{
    /// <inheritdoc />
    public partial class _1002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_AccountsTypes_typeAccountId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_typeAccountId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "typeAccountId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "typeAcccountId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RegistrationViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    typeAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationViewModel_AccountsTypes_typeAccountId",
                        column: x => x.typeAccountId,
                        principalTable: "AccountsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationViewModel_typeAccountId",
                table: "RegistrationViewModel",
                column: "typeAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationViewModel");

            migrationBuilder.DropColumn(
                name: "typeAcccountId",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Client",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "typeAccountId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_typeAccountId",
                table: "Client",
                column: "typeAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_AccountsTypes_typeAccountId",
                table: "Client",
                column: "typeAccountId",
                principalTable: "AccountsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
