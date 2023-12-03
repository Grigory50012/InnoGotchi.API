using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoGotchi.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyParts",
                columns: table => new
                {
                    BodyPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyParts", x => x.BodyPartId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.FarmId);
                    table.ForeignKey(
                        name: "FK_Farms_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborations",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborations", x => new { x.UserProfileId, x.FarmId });
                    table.ForeignKey(
                        name: "FK_Collaborations_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId");
                    table.ForeignKey(
                        name: "FK_Collaborations_Users_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "Users",
                        principalColumn: "UserProfileId");
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaysOfHappiness = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrinkingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyPartPet",
                columns: table => new
                {
                    BodyPartsBodyPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetsPetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyPartPet", x => new { x.BodyPartsBodyPartId, x.PetsPetId });
                    table.ForeignKey(
                        name: "FK_BodyPartPet_BodyParts_BodyPartsBodyPartId",
                        column: x => x.BodyPartsBodyPartId,
                        principalTable: "BodyParts",
                        principalColumn: "BodyPartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodyPartPet_Pets_PetsPetId",
                        column: x => x.PetsPetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyParts",
                columns: new[] { "BodyPartId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("0915c10a-2988-4ea8-a956-682e49447401"), "nose6.svg", "Nose" },
                    { new Guid("0c005e01-4116-459a-bdba-02ccfcc028ae"), "eyes4.svg", "Eyes" },
                    { new Guid("1238384b-7b34-4552-905d-cd9a9f467e4f"), "eyes1.svg", "Eyes" },
                    { new Guid("12a069ba-b2c0-41ed-937e-a692c80382bd"), "body5.svg", "Body" },
                    { new Guid("23886d38-9d49-4b23-9c63-3a1d95bbd56a"), "mouth2.svg", "Mouth" },
                    { new Guid("2fed2577-e95d-4d54-84e3-b1938cab02b0"), "nose1.svg", "Nose" },
                    { new Guid("3a476d22-c79a-4a31-bbf2-e7ade8836ab7"), "nose3.svg", "Nose" },
                    { new Guid("3d4a10be-9217-4ff9-9f7d-456ae9859d5f"), "mouth3.svg", "Mouth" },
                    { new Guid("54f39dbf-3c9d-47d7-aef4-c37da00f2050"), "eyes6.svg", "Eyes" },
                    { new Guid("74b4f808-699a-4488-b2de-9b2d4b396c77"), "eyes2.svg", "Eyes" },
                    { new Guid("7544cbc5-8277-49e4-87db-71f836fdf2e3"), "mouth5.svg", "Mouth" },
                    { new Guid("7571ae17-cc89-405d-8cfc-26da317519b0"), "mouth1.svg", "Mouth" },
                    { new Guid("84baae8a-8d2c-4b68-9d43-92927d174f70"), "nose4.svg", "Nose" },
                    { new Guid("85883b2e-23af-45e5-8514-c2f490af90a5"), "nose5.svg", "Nose" },
                    { new Guid("944f6994-cd24-453c-b5b7-6935204bfb36"), "body1.svg", "Body" },
                    { new Guid("abbd653d-9680-4a0c-a485-3ec45d083bdc"), "body2.svg", "Body" },
                    { new Guid("b552a88f-8c93-4ab1-bde0-d40e25323d86"), "nose2.svg", "Nose" },
                    { new Guid("c5d6e6d8-a8bd-45f1-bf21-f0225fb7e505"), "eyes3.svg", "Eyes" },
                    { new Guid("cccc548f-4e0e-4d81-bf42-d04c18fedbca"), "body3.svg", "Body" },
                    { new Guid("df44186a-08cb-454a-95ac-09e98800ef2d"), "body4.svg", "Body" },
                    { new Guid("f03a8c14-6e8d-4ab3-a569-d28117fcbc56"), "mouth4.svg", "Mouth" },
                    { new Guid("f6bda2d8-d5dd-47a0-a77c-0dbaff44b18a"), "eyes5.svg", "Eyes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyPartPet_PetsPetId",
                table: "BodyPartPet",
                column: "PetsPetId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborations_FarmId",
                table: "Collaborations",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_Name",
                table: "Farms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farms_OwnerId",
                table: "Farms",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FarmId",
                table: "Pets",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_Name",
                table: "Pets",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyPartPet");

            migrationBuilder.DropTable(
                name: "Collaborations");

            migrationBuilder.DropTable(
                name: "BodyParts");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
