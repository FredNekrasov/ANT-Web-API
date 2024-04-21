using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlexanderNevskyTemple.DAL.Migrations;

/// <inheritdoc />
public partial class InitANTDb : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Catalogs",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Catalogs", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Articles",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                CatalogId = table.Column<int>(type: "int", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Articles", x => x.Id);
                table.ForeignKey(
                    name: "FK_Articles_Catalogs_CatalogId",
                    column: x => x.CatalogId,
                    principalTable: "Catalogs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Contents",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                ArticleId = table.Column<long>(type: "bigint", nullable: true),
                URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Contents", x => x.Id);
                table.ForeignKey(
                    name: "FK_Contents_Articles_ArticleId",
                    column: x => x.ArticleId,
                    principalTable: "Articles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(name: "IX_Articles_CatalogId", table: "Articles", column: "CatalogId");
        migrationBuilder.CreateIndex(name: "IX_Contents_ArticleId", table: "Contents", column: "ArticleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Contents");
        migrationBuilder.DropTable(name: "Articles");
        migrationBuilder.DropTable(name: "Catalogs");
    }
}