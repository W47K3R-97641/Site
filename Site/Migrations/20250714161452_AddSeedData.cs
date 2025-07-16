using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "DemoLink", "Description", "GitHubLink", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://simple.cruip.com", "An open-source site built to demo Unity-powered collaborations.", "https://github.com/unityshowcase/demo", "https://img.freepik.com/vecteurs-libre/ensemble-modeles-conception-page-destination-site-web-moderne-pour-telephone-mobile-tablette-articles-galerie-formulaire-contact-illustration-isolee-plat_1284-60948.jpg?semt=ais_hybrid&w=740", "Ecommerce Project" },
                    { 4, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://simple.cruip.com", "An open-source site built to demo Unity-powered collaborations.", "https://github.com/unityshowcase/demo", "https://img.freepik.com/vecteurs-libre/ensemble-modeles-conception-page-destination-site-web-moderne-pour-telephone-mobile-tablette-articles-galerie-formulaire-contact-illustration-isolee-plat_1284-60948.jpg?semt=ais_hybrid&w=740", "Potflio" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "Description", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "frontend", "", "Blazor" },
                    { 5, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "api", "", "Asp.net" }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkills",
                columns: new[] { "ProjectsId", "SkillsId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectsId", "SkillsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectsId", "SkillsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectsId", "SkillsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectsId", "SkillsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectsId", "SkillsId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
