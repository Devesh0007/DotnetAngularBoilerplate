using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotnetAngularBoilerplate.Entity.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0060ea57-b4db-4712-8d9e-448d7fac472e", "3", "Manager", "Manager" },
                    { "684c9691-3669-4262-8c37-58215051c814", "4", "Analyst", "Analyst" },
                    { "a24a42e1-59c9-452e-af8e-8177821e2af0", "1", "GlobalAdmin", "GlobalAdmin" },
                    { "ba3f75a6-d76b-41a1-9aa9-eaa93d88cbd2", "2", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0060ea57-b4db-4712-8d9e-448d7fac472e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "684c9691-3669-4262-8c37-58215051c814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24a42e1-59c9-452e-af8e-8177821e2af0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba3f75a6-d76b-41a1-9aa9-eaa93d88cbd2");
        }
    }
}
