using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPaws.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class undoupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetIds",
                table: "Activitys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "PetIds",
                table: "Activitys",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }
    }
}
