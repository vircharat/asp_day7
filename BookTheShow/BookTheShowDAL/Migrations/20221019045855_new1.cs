using Microsoft.EntityFrameworkCore.Migrations;

namespace BookTheShowDAL.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTicketPrice",
                table: "moviesv",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTicketPrice",
                table: "moviesv");
        }
    }
}
