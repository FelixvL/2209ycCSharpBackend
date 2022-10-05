using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContextSkillsDB.Migrations
{
    public partial class getalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doelen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Belangrijkheid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doelen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subgoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subgoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNaam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GoalProgress = table.Column<int>(type: "int", nullable: false),
                    SubGoalProgress = table.Column<int>(type: "int", nullable: false),
                    IsExpert = table.Column<bool>(type: "bit", nullable: false),
                    DoelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_doelen_DoelId",
                        column: x => x.DoelId,
                        principalTable: "doelen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_DoelId",
                table: "users",
                column: "DoelId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_UserNaam",
                table: "users",
                column: "UserNaam",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subgoal");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "doelen");
        }
    }
}
