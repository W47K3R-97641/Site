using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class fixtemdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DemoLink", "ImageUrl" },
                values: new object[] { "https://simple.cruip.com", "https://i.pinimg.com/736x/d3/3d/32/d33d326d8465cf9663652a4f0c426159.jpg" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DemoLink", "ImageUrl" },
                values: new object[] { "https://simple.cruip.com", "https://img.freepik.com/vecteurs-libre/ensemble-modeles-conception-page-destination-site-web-moderne-pour-telephone-mobile-tablette-articles-galerie-formulaire-contact-illustration-isolee-plat_1284-60948.jpg?semt=ais_hybrid&w=740" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DemoLink", "ImageUrl" },
                values: new object[] { "https://demo.walkerplatform.com", "/images/projects/walker-creator.png" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DemoLink", "ImageUrl" },
                values: new object[] { "https://unityshowcase.com", "/images/projects/unity-showcase.png" });
        }
    }
}
