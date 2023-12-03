using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoGotchi.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTheFarmCollaborationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborations_AspNetUsers_UserId",
                table: "Collaborations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations",
                columns: new[] { "FarmId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborations_AspNetUsers_UserId",
                table: "Collaborations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborations_AspNetUsers_UserId",
                table: "Collaborations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborations",
                table: "Collaborations",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborations_AspNetUsers_UserId",
                table: "Collaborations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
