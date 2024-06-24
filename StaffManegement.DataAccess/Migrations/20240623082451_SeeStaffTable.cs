using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffManegement.DataAccess.Migrations
{
    public partial class SeeStaffTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "usmon@gmial.com", "Usmon", "G'oziy" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 4, "jalol@gmial.com", "Jaloliddin", "Manguberdi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
