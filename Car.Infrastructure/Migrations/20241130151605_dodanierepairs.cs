using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dodanierepairs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Cars_CarId",
                table: "Repair");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Users_MechanicId",
                table: "Repair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repair",
                table: "Repair");

            migrationBuilder.RenameTable(
                name: "Repair",
                newName: "Repairs");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_MechanicId",
                table: "Repairs",
                newName: "IX_Repairs_MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_CarId",
                table: "Repairs",
                newName: "IX_Repairs_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repairs",
                table: "Repairs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Cars_CarId",
                table: "Repairs",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Users_MechanicId",
                table: "Repairs",
                column: "MechanicId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Cars_CarId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Users_MechanicId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repairs",
                table: "Repairs");

            migrationBuilder.RenameTable(
                name: "Repairs",
                newName: "Repair");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_MechanicId",
                table: "Repair",
                newName: "IX_Repair_MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_CarId",
                table: "Repair",
                newName: "IX_Repair_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repair",
                table: "Repair",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Cars_CarId",
                table: "Repair",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Users_MechanicId",
                table: "Repair",
                column: "MechanicId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
