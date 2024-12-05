using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Users_Id_Mechanic",
                table: "Repair");

            migrationBuilder.DropColumn(
                name: "Id_Car",
                table: "Repair");

            migrationBuilder.RenameColumn(
                name: "Id_Mechanic",
                table: "Repair",
                newName: "MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_Id_Mechanic",
                table: "Repair",
                newName: "IX_Repair_MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Users_MechanicId",
                table: "Repair",
                column: "MechanicId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Users_MechanicId",
                table: "Repair");

            migrationBuilder.RenameColumn(
                name: "MechanicId",
                table: "Repair",
                newName: "Id_Mechanic");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_MechanicId",
                table: "Repair",
                newName: "IX_Repair_Id_Mechanic");

            migrationBuilder.AddColumn<int>(
                name: "Id_Car",
                table: "Repair",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Users_Id_Mechanic",
                table: "Repair",
                column: "Id_Mechanic",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
