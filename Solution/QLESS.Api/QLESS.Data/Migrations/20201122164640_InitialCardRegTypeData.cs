using Microsoft.EntityFrameworkCore.Migrations;

namespace QLESS.Data.Migrations
{
    public partial class InitialCardRegTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO CardRegTypes(CardRegTypeDesc,CardRegTypeFormat,Discount,DailyAdditionalDiscount,MaxDailyAdditionalDiscount) Values('Regular','',0,0,0)");
            migrationBuilder.Sql($"INSERT INTO CardRegTypes(CardRegTypeDesc,CardRegTypeFormat,Discount,DailyAdditionalDiscount,MaxDailyAdditionalDiscount) Values('Senior Citizen Discount','##-####-####',0,0,0)");
            migrationBuilder.Sql($"INSERT INTO CardRegTypes(CardRegTypeDesc,CardRegTypeFormat,Discount,DailyAdditionalDiscount,MaxDailyAdditionalDiscount) Values('PWD Discount','####-####-####',0,0,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
