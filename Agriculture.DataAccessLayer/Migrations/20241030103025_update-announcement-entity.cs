using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateannouncemententity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_announcements",
                table: "announcements");

            migrationBuilder.RenameTable(
                name: "announcements",
                newName: "Announcements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements",
                column: "AnnouncementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements");

            migrationBuilder.RenameTable(
                name: "Announcements",
                newName: "announcements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_announcements",
                table: "announcements",
                column: "AnnouncementId");
        }
    }
}
