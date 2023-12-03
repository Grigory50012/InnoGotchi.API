using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoGotchi.Migrations
{
    /// <inheritdoc />
    public partial class AddCollaborations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Collaborations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Collaborations_UserId",
                table: "Collaborations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborations_AspNetUsers_UserId",
                table: "Collaborations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborations_AspNetUsers_UserId",
                table: "Collaborations");

            migrationBuilder.DropIndex(
                name: "IX_Collaborations_UserId",
                table: "Collaborations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Collaborations");
        }
    }
}
