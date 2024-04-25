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
                    CompanyLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyCoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "CompanyId", "CompanyCoverImageUrl", "CreatedAt", "DeletedAt", "CompanyDescription", "CompanyEmail", "CompanyLogoUrl", "CompanyName", "CompanyPhoneNumber", "UpdatedAt", "CompanyWebsite" },
                values: new object[,]
                {
                    { new Guid("ce041a71-f3ee-4204-90a6-9dcca8f643e2"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ULUARS HOLDING is a company that provides software solutions.", "uluars@uluars.com", "", "ULUARS HOLDING", "+1234567890", null, "www.uluars.com" },
                    { new Guid("d7bc7caf-2c92-4ed8-a31e-d1b5f478c701"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uluksar is a company that provides software solutions.", "test@test.com", "", "Uluksar", "+1234567890", null, "www.uluksar.com" },
                    { new Guid("dd0136f3-8eb2-471d-90be-a1be18cfc849"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Digitalhat is a company that provides software solutions.", "dgtalhat@dgtalhat.com", "", "Digitalhat", "+1234567890", null, "www.digitalhat.com" }
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
