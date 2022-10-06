﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContextSkillsDB.Migrations
{
    public partial class getalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goals", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GoalProgress = table.Column<int>(type: "int", nullable: false),
                    SubGoalProgress = table.Column<int>(type: "int", nullable: false),
                    IsExpert = table.Column<bool>(type: "bit", nullable: false),
                    DoelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
<<<<<<<< HEAD:DBContextSkillsDB/Migrations/20221005132906_test.cs
                });

========
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

>>>>>>>> master:DBContextSkillsDB/Migrations/20221005145511_get all tables.cs
            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_UserName",
                table: "users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<<< HEAD:DBContextSkillsDB/Migrations/20221005132906_test.cs
                name: "goals");

            migrationBuilder.DropTable(
========
>>>>>>>> master:DBContextSkillsDB/Migrations/20221005145511_get all tables.cs
                name: "subgoal");

            migrationBuilder.DropTable(
                name: "users");
<<<<<<<< HEAD:DBContextSkillsDB/Migrations/20221005132906_test.cs
========

            migrationBuilder.DropTable(
                name: "doelen");
>>>>>>>> master:DBContextSkillsDB/Migrations/20221005145511_get all tables.cs
        }
    }
}
