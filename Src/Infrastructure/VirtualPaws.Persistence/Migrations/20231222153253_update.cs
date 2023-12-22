using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPaws.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityPet_Activitys_ActivitiesId",
                table: "ActivityPet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityPet",
                table: "ActivityPet");

            migrationBuilder.DropIndex(
                name: "IX_ActivityPet_PetsId",
                table: "ActivityPet");

            migrationBuilder.RenameColumn(
                name: "ActivitiesId",
                table: "ActivityPet",
                newName: "PetsIds");

            migrationBuilder.AddColumn<int[]>(
                name: "PetIds",
                table: "Activitys",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityPet",
                table: "ActivityPet",
                columns: new[] { "PetsId", "PetsIds" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPet_PetsIds",
                table: "ActivityPet",
                column: "PetsIds");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityPet_Activitys_PetsIds",
                table: "ActivityPet",
                column: "PetsIds",
                principalTable: "Activitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityPet_Activitys_PetsIds",
                table: "ActivityPet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityPet",
                table: "ActivityPet");

            migrationBuilder.DropIndex(
                name: "IX_ActivityPet_PetsIds",
                table: "ActivityPet");

            migrationBuilder.DropColumn(
                name: "PetIds",
                table: "Activitys");

            migrationBuilder.RenameColumn(
                name: "PetsIds",
                table: "ActivityPet",
                newName: "ActivitiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityPet",
                table: "ActivityPet",
                columns: new[] { "ActivitiesId", "PetsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPet_PetsId",
                table: "ActivityPet",
                column: "PetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityPet_Activitys_ActivitiesId",
                table: "ActivityPet",
                column: "ActivitiesId",
                principalTable: "Activitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
