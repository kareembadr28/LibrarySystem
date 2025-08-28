using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublisher_Publishers_publishersid",
                table: "BookPublisher");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Publishers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "publishersid",
                table: "BookPublisher",
                newName: "publishersId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPublisher_publishersid",
                table: "BookPublisher",
                newName: "IX_BookPublisher_publishersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublisher_Publishers_publishersId",
                table: "BookPublisher",
                column: "publishersId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublisher_Publishers_publishersId",
                table: "BookPublisher");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publishers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "publishersId",
                table: "BookPublisher",
                newName: "publishersid");

            migrationBuilder.RenameIndex(
                name: "IX_BookPublisher_publishersId",
                table: "BookPublisher",
                newName: "IX_BookPublisher_publishersid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublisher_Publishers_publishersid",
                table: "BookPublisher",
                column: "publishersid",
                principalTable: "Publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
