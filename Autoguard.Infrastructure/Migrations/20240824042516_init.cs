using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autoguard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RegNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BusinessContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    GeoLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaxNumber = table.Column<long>(type: "BIGINT", nullable: false),
                    CipcFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PsiraDocumentationFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PayeNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OperationalCountry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BusinessLogoImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NumberOfPeople = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
