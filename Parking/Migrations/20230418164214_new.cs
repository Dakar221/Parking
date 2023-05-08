using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Personne_LocataireId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Voiture_LavitureId",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Voiture",
                newName: "VoitureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Personne",
                newName: "PersonneId");

            migrationBuilder.RenameColumn(
                name: "LocataireId",
                table: "Location",
                newName: "VoitureId");

            migrationBuilder.RenameColumn(
                name: "LavitureId",
                table: "Location",
                newName: "PersonneId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_LocataireId",
                table: "Location",
                newName: "IX_Location_VoitureId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_LavitureId",
                table: "Location",
                newName: "IX_Location_PersonneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Personne_PersonneId",
                table: "Location",
                column: "PersonneId",
                principalTable: "Personne",
                principalColumn: "PersonneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Voiture_VoitureId",
                table: "Location",
                column: "VoitureId",
                principalTable: "Voiture",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Personne_PersonneId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Voiture_VoitureId",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "VoitureId",
                table: "Voiture",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonneId",
                table: "Personne",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VoitureId",
                table: "Location",
                newName: "LocataireId");

            migrationBuilder.RenameColumn(
                name: "PersonneId",
                table: "Location",
                newName: "LavitureId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Location",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Location_VoitureId",
                table: "Location",
                newName: "IX_Location_LocataireId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_PersonneId",
                table: "Location",
                newName: "IX_Location_LavitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Personne_LocataireId",
                table: "Location",
                column: "LocataireId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Voiture_LavitureId",
                table: "Location",
                column: "LavitureId",
                principalTable: "Voiture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
