using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLESS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardLoadHists",
                columns: table => new
                {
                    CardLoadRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CardLoadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardLoadFr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardLoadTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FareDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FareDailyAdditionalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLoadHists", x => x.CardLoadRef);
                });

            migrationBuilder.CreateTable(
                name: "CardRegTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardRegTypeDesc = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CardRegTypeFormat = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyAdditionalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxDailyAdditionalDiscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRegTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CardRegTypeId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardLoadHists");

            migrationBuilder.DropTable(
                name: "CardRegTypes");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
