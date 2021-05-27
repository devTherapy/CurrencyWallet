using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyWallet.Persistence.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tranasactions");

            migrationBuilder.AddColumn<string>(
                name: "TransactionTypeId",
                table: "Tranasactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tranasactions_TransactionTypeId",
                table: "Tranasactions",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranasactions_TransactionType_TransactionTypeId",
                table: "Tranasactions",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tranasactions_TransactionType_TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_Tranasactions_TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tranasactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
