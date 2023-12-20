using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessNavigator1.Migrations
{
    /// <inheritdoc />
    public partial class adding_title_to_journal_entries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "JournalEntries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "JournalEntries");
        }
    }
}
