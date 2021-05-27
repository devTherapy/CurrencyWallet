using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyWallet.Persistence.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tranasactions_TransactionType_TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "TransactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranasactions_TransactionTypes_TransactionTypeId",
                table: "Tranasactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tranasactions_TransactionTypes_TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranasactions_TransactionType_TransactionTypeId",
                table: "Tranasactions",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
