using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RenamedGenreCountryCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Genres",
                newName: "CountryCodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCodes",
                table: "Genres",
                newName: "CountryCode");
        }
    }
}
