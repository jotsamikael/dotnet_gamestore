using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    idGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameGame = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    releasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<int>(type: "int", precision: 16, scale: 6, nullable: false),
                    imageUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.idGame);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
