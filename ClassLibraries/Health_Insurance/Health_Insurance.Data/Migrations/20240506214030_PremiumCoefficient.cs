using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Insurance.Data.Migrations
{
    public partial class PremiumCoefficient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "InsuranceRequests",
                newName: "Capital");

            migrationBuilder.AddColumn<float>(
                name: "PremiumCoefficient",
                table: "Coverages",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumCoefficient",
                table: "Coverages");

            migrationBuilder.RenameColumn(
                name: "Capital",
                table: "InsuranceRequests",
                newName: "Amount");
        }
    }
}
