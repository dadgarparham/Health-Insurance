using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance.Data.Migrations
{
    public partial class ChangePremiumCoefficientType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PremiumCoefficient",
                table: "Coverages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PremiumCoefficient",
                table: "Coverages",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
