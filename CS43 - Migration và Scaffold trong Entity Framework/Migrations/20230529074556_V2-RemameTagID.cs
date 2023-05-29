using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS43___Migration_và_Scaffold_trong_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class V2RemameTagID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIdNew",
                table: "Tags",
                newName: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "TagIdNew");
        }
    }
}
