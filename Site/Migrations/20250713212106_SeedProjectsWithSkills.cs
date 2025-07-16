using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjectsWithSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DemoLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    GitHubLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => new { x.ProjectsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Completed", "CreatedAt", "DemoLink", "Description", "GitHubLink", "ImageUrl", "Name" },
                values: new object[] { 1, true, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://demo.walkerplatform.com", "A platform for Walkers to create and share projects.", "https://github.com/walkercreator/walkerplatform", "/images/projects/walker-creator.png", "Walker Creator Platform" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "DemoLink", "Description", "GitHubLink", "ImageUrl", "Name" },
                values: new object[] { 2, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://unityshowcase.com", "An open-source site built to demo Unity-powered collaborations.", "https://github.com/unityshowcase/demo", "/images/projects/unity-showcase.png", "Unity Showcase" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "Description", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Backend", "", "C#" },
                    { 2, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Frontend", "", "React" },
                    { 3, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Database", "", "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkills",
                columns: new[] { "ProjectsId", "SkillsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_SkillsId",
                table: "ProjectSkills",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
