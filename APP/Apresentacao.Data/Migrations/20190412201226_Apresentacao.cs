using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apresentacao.Data.Migrations
{
    public partial class Apresentacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodeAirplane = table.Column<string>(maxLength: 255, nullable: true),
                    CountPassengers = table.Column<int>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fullname = table.Column<string>(maxLength: 255, nullable: true),
                    Username = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateRegister", "Email", "Fullname", "Password", "Username" },
                values: new object[] { 1, new DateTime(2019, 4, 12, 17, 12, 26, 104, DateTimeKind.Local), "romy.moura23@gmail.com", "Romy G. Moura", "teste123", "romy.moura" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airplane");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
