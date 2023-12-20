using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessNavigator1.Migrations
{
    /// <inheritdoc />
    public partial class crackedflag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CrackedAccounts");

            migrationBuilder.AddColumn<bool>(
                name: "cracked",
                table: "UserAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cracked",
                table: "UserAccounts");

            //migrationBuilder.CreateTable(
            //    name: "CrackedAccounts",
            //    columns: table => new
            //    {
            //        userID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        crackDetection = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        displayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        hashSelection = table.Column<int>(type: "int", nullable: false),
            //        password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        plaintext_password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CrackedAccounts", x => x.userID);
            //    });
        }
    }
}
