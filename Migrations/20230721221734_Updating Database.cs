using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessNavigator1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entryPage",
                table: "JournalEntries");

            migrationBuilder.RenameColumn(
                name: "sentimentType",
                table: "JournalEntries",
                newName: "SentimentType");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "JournalEntries",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "JournalEntries");

            migrationBuilder.RenameColumn(
                name: "SentimentType",
                table: "JournalEntries",
                newName: "sentimentType");

            migrationBuilder.AddColumn<string>(
                name: "entryPage",
                table: "JournalEntries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
