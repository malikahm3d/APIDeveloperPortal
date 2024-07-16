using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDeveloperPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class UserAddstudenItcolmun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Users");
        }
    }
}
