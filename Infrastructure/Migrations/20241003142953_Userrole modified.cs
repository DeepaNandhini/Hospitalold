using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Userrolemodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "RoleId",
            //    table: "UserRoles",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "UserId",
            //    table: "UserRoles",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            //migrationBuilder.AlterColumn<int>(
            //    name: "RoleId",
            //    table: "UserRoles",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");

            //migrationBuilder.AlterColumn<int>(
            //    name: "UserId",
            //    table: "UserRoles",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");

            
        }
    }
}
