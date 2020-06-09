using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProject.Migrations
{
    public partial class AddComposites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OverallRating",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
