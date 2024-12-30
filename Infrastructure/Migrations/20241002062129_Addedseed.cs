using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addedseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("3b514dc9-8326-4c3b-90b3-ae58dee0a7ef"), "SuperAdmin" },
                    { new Guid("a8367e37-f9e7-4117-8472-3271674ae875"), "Admin" },
                    { new Guid("b39175af-e75e-4082-937d-c01219d8f2c5"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("3b514dc9-8326-4c3b-90b3-ae58dee0a7ef"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a8367e37-f9e7-4117-8472-3271674ae875"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b39175af-e75e-4082-937d-c01219d8f2c5"));
        }
    }
}
