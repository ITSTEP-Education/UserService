using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studySection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studyHours = table.Column<int>(type: "int", nullable: false),
                    isOnline = table.Column<bool>(type: "bit", nullable: false),
                    teacher = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderdetails");
        }
    }
}
