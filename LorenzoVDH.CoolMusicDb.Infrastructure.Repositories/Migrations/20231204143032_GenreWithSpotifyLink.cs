using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class GenreWithSpotifyLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpotifyTrackPreviewId",
                table: "Genres",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotifyTrackPreviewId",
                table: "Genres");
        }
    }
}
