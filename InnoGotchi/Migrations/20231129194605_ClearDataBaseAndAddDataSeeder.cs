using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoGotchi.Migrations
{
    /// <inheritdoc />
    public partial class ClearDataBaseAndAddDataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ac8240a-8498-4869-bc86-60e5dc982d27"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("0915c10a-2988-4ea8-a956-682e49447401"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("0c005e01-4116-459a-bdba-02ccfcc028ae"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("1238384b-7b34-4552-905d-cd9a9f467e4f"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("12a069ba-b2c0-41ed-937e-a692c80382bd"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("23886d38-9d49-4b23-9c63-3a1d95bbd56a"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("2fed2577-e95d-4d54-84e3-b1938cab02b0"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("3a476d22-c79a-4a31-bbf2-e7ade8836ab7"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("3d4a10be-9217-4ff9-9f7d-456ae9859d5f"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("54f39dbf-3c9d-47d7-aef4-c37da00f2050"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("74b4f808-699a-4488-b2de-9b2d4b396c77"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("7544cbc5-8277-49e4-87db-71f836fdf2e3"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("7571ae17-cc89-405d-8cfc-26da317519b0"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("84baae8a-8d2c-4b68-9d43-92927d174f70"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("85883b2e-23af-45e5-8514-c2f490af90a5"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("944f6994-cd24-453c-b5b7-6935204bfb36"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("abbd653d-9680-4a0c-a485-3ec45d083bdc"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("b552a88f-8c93-4ab1-bde0-d40e25323d86"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("c5d6e6d8-a8bd-45f1-bf21-f0225fb7e505"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("cccc548f-4e0e-4d81-bf42-d04c18fedbca"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("df44186a-08cb-454a-95ac-09e98800ef2d"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("f03a8c14-6e8d-4ab3-a569-d28117fcbc56"));

            migrationBuilder.DeleteData(
                table: "BodyParts",
                keyColumn: "BodyPartId",
                keyValue: new Guid("f6bda2d8-d5dd-47a0-a77c-0dbaff44b18a"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4ac8240a-8498-4869-bc86-60e5dc982d27"), null, "User", "USER" });

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
        }
    }
}
