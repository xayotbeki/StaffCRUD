using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffManegement.DataAccess.Migrations
{
    public partial class PhotoFilePahtPropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFilePath",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFilePath",
                table: "Staffs");
        }
    }
}
