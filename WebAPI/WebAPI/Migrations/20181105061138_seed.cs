using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ID", "Completed", "Name" },
                values: new object[] { 1, false, "Vacuum the carpet" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ID", "Completed", "Name" },
                values: new object[] { 2, false, "Mop the floors" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ID", "Completed", "Name" },
                values: new object[] { 3, true, "Finish some labs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
