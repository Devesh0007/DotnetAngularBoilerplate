using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotnetAngularBoilerplate.Entity.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedIdentityUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54f0e209-5d8d-404a-bb20-711a99572372", "3", "Manager", "Manager" },
                    { "9035dd1f-8709-4371-ab1f-b6254c72b655", "2", "Admin", "Admin" },
                    { "bf37c61e-89cf-4554-8f1a-949da2e7993e", "1", "GlobalAdmin", "GlobalAdmin" },
                    { "da778f39-53c0-40b5-9896-57af71968dd5", "4", "Analyst", "Analyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54f0e209-5d8d-404a-bb20-711a99572372");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9035dd1f-8709-4371-ab1f-b6254c72b655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf37c61e-89cf-4554-8f1a-949da2e7993e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da778f39-53c0-40b5-9896-57af71968dd5");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

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
    }
}
