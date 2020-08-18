using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorHub.Data.Migrations
{
    public partial class UserAndErrorOcurrenceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "error_occurrence",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level = table.Column<int>(nullable: false),
                    environment = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    archivied_record = table.Column<bool>(nullable: false),
                    origin = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("error_occurrence_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(nullable: false),
                    hash_password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "error_occurrence");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
