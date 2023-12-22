using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPaws.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemodelcreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityPet_Activitys_PetsIds",
                table: "ActivityPet");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityPet_Pets_PetsId",
                table: "ActivityPet");

            migrationBuilder.RenameColumn(
                name: "PetsIds",
                table: "ActivityPet",
                newName: "ActivityId");

            migrationBuilder.RenameColumn(
                name: "PetsId",
                table: "ActivityPet",
                newName: "PetId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityPet_PetsIds",
                table: "ActivityPet",
                newName: "IX_ActivityPet_ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityPet_Activitys_ActivityId",
                table: "ActivityPet",
                column: "ActivityId",
                principalTable: "Activitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityPet_Pets_PetId",
                table: "ActivityPet",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityPet_Activitys_ActivityId",
                table: "ActivityPet");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityPet_Pets_PetId",
                table: "ActivityPet");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "ActivityPet",
                newName: "PetsIds");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "ActivityPet",
                newName: "PetsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityPet_ActivityId",
                table: "ActivityPet",
                newName: "IX_ActivityPet_PetsIds");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityPet_Activitys_PetsIds",
                table: "ActivityPet",
                column: "PetsIds",
                principalTable: "Activitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityPet_Pets_PetsId",
                table: "ActivityPet",
                column: "PetsId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
