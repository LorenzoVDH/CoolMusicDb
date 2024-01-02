using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class GenrePopularArtistConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenrePopularArtists",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    PopularArtistsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenrePopularArtists", x => new { x.GenreId, x.PopularArtistsId });
                    table.ForeignKey(
                        name: "FK_GenrePopularArtists_Artists_PopularArtistsId",
                        column: x => x.PopularArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenrePopularArtists_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenrePopularArtists_PopularArtistsId",
                table: "GenrePopularArtists",
                column: "PopularArtistsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenrePopularArtists");
        }
    }
}
