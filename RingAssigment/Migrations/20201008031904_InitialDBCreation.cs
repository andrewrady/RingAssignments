using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RingAssigment.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RingNumber = table.Column<int>(nullable: false),
                    Rank = table.Column<string>(maxLength: 100, nullable: false),
                    AgeRange = table.Column<string>(maxLength: 25, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    Division = table.Column<string>(maxLength: 100, nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ring", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ring");
        }
    }
}
