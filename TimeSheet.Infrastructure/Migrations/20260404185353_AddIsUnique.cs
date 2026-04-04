using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectAssignment_UserId",
                table: "ProjectAssignment");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Activity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignment_UserId_ProjectId",
                table: "ProjectAssignment",
                columns: new[] { "UserId", "ProjectId" },
                unique: true,
                filter: "\"IsActive\" = TRUE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectAssignment_UserId_ProjectId",
                table: "ProjectAssignment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Activity");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignment_UserId",
                table: "ProjectAssignment",
                column: "UserId");
        }
    }
}
