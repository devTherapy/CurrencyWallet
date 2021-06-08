using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyWallet.Persistence.Migrations
{
    public partial class DBrestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tranasactions_TransactionStatuses_TransactionStatusId",
                table: "Tranasactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranasactions_TransactionTypes_TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.DropTable(
                name: "TransactionStatuses");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tranasactions_TransactionStatusId",
                table: "Tranasactions");

            migrationBuilder.DropIndex(
                name: "IX_Tranasactions_TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.DropColumn(
                name: "TransactionStatusId",
                table: "Tranasactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Tranasactions");

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatus",
                table: "Tranasactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "Tranasactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Tranasactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Tranasactions");

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatusId",
                table: "Tranasactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionTypeId",
                table: "Tranasactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tranasactions_TransactionStatusId",
                table: "Tranasactions",
                column: "TransactionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tranasactions_TransactionTypeId",
                table: "Tranasactions",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranasactions_TransactionStatuses_TransactionStatusId",
                table: "Tranasactions",
                column: "TransactionStatusId",
                principalTable: "TransactionStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tranasactions_TransactionTypes_TransactionTypeId",
                table: "Tranasactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
