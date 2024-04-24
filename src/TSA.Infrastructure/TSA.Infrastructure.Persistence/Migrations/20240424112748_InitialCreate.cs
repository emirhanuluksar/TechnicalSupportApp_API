using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TSA.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CreatedAt", "DeletedAt", "CompanyDescription", "CompanyEmail", "CompanyName", "CompanyPhoneNumber", "UpdatedAt", "CompanyWebsite" },
                values: new object[,]
                {
                    { new Guid("5ade0738-cf4c-4913-9b92-6107bc4401be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Digitalhat is a company that provides software solutions.", "dgtalhat@dgtalhat.com", "Digitalhat", "+1234567890", null, "www.digitalhat.com" },
                    { new Guid("842d41ec-b8f3-4b1f-8fe9-c90a59165746"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uluksar is a company that provides software solutions.", "test@test.com", "Uluksar", "+1234567890", null, "www.uluksar.com" },
                    { new Guid("e2d92c2d-2de6-4e8f-a0a8-e2330f1503c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ULUARS HOLDING is a company that provides software solutions.", "uluars@uluars.com", "ULUARS HOLDING", "+1234567890", null, "www.uluars.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
