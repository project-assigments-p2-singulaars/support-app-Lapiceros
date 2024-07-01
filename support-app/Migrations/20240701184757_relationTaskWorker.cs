using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace support_app.Migrations
{
    /// <inheritdoc />
    public partial class relationTaskWorker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Duties_TaskAssignedId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TaskAssignedId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TaskAssignedId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskId",
                table: "Workers",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Duties_TaskId",
                table: "Workers",
                column: "TaskId",
                principalTable: "Duties",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskAssignedId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskAssignedId",
                table: "Workers",
                column: "TaskAssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Duties_TaskAssignedId",
                table: "Workers",
                column: "TaskAssignedId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
