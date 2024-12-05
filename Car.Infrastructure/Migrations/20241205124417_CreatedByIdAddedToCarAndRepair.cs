using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdAddedToCarAndRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Repairs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CreatedById",
                table: "Repairs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CreatedById",
                table: "Cars",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_CreatedById",
                table: "Cars",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_AspNetUsers_CreatedById",
                table: "Repairs",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_CreatedById",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_AspNetUsers_CreatedById",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_CreatedById",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CreatedById",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cars");
        }
    }
}
