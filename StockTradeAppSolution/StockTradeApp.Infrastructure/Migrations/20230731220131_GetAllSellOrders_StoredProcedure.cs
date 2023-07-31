using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTradeApp.Infrastructure.Migrations
{
    public partial class GetAllSellOrders_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string Sp_GetAllSellOrders = @"
            CREATE PROCEDURE [dbo].[GetAllSellOrders] 
            AS BEGIN
            SELECT SellOrderID, StockSymbol, StockName, DateAndTimeOfOrder,Quantity, Price
            FROM [dbo].[SellOrders]
            
            END
            ";

            migrationBuilder.Sql(Sp_GetAllSellOrders);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string Sp_GetAllSellOrders = @"
            DROP PROCEDURE [dbo].[GetAllSellOrders]
            ";

            migrationBuilder.Sql(Sp_GetAllSellOrders);
        }
    }
}
