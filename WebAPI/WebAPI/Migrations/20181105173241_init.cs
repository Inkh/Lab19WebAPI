using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    ToDoListID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ToDos_ToDoList_ToDoListID",
                        column: x => x.ToDoListID,
                        principalTable: "ToDoList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Chores" });

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Programming" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ID", "Completed", "Name", "ToDoListID" },
                values: new object[] { 1, false, "Vacuum the carpet", 1 });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ID", "Completed", "Name", "ToDoListID" },
                values: new object[] { 2, false, "Mop the floors", 1 });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ID", "Completed", "Name", "ToDoListID" },
                values: new object[] { 3, true, "Finish some labs", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ToDoListID",
                table: "ToDos",
                column: "ToDoListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "ToDoList");
        }
    }
}
