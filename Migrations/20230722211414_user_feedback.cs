using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessNavigator1.Migrations
{
    /// <inheritdoc />
    public partial class user_feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Useful = table.Column<bool>(type: "bit", nullable: false),
                    wouldUseAgain = table.Column<bool>(type: "bit", nullable: false),
                    wouldContinueToUse = table.Column<bool>(type: "bit", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

        }
    }
}
