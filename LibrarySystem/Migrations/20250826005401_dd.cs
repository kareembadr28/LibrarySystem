using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_userId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_userId",
                table: "Purchases");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Purchases",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_userId",
                table: "Purchases",
                newName: "IX_Purchases_customerId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Borrows",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_userId",
                table: "Borrows",
                newName: "IX_Borrows_customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Customers_customerId",
                table: "Borrows",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Customers_customerId",
                table: "Purchases",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Customers_customerId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Customers_customerId",
                table: "Purchases");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Purchases",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_customerId",
                table: "Purchases",
                newName: "IX_Purchases_userId");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Borrows",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_customerId",
                table: "Borrows",
                newName: "IX_Borrows_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_userId",
                table: "Borrows",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_userId",
                table: "Purchases",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
