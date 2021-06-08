using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyWallet.Persistence.Migrations
{
    public partial class updatedtransactionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceAfterTransaction",
                table: "Tranasactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceBeforeTransaction",
                table: "Tranasactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceAfterTransaction",
                table: "Tranasactions");

            migrationBuilder.DropColumn(
                name: "BalanceBeforeTransaction",
                table: "Tranasactions");
        }
    }
}
