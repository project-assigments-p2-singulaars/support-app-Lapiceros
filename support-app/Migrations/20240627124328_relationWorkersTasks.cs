using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace support_app.Migrations
{
    /// <inheritdoc />
    public partial class relationWorkersTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskId",
                table: "Workers",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Duties_TaskId",
                table: "Workers",
                column: "TaskId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Duties_TaskId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TaskId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Workers");
        }
    }
}
