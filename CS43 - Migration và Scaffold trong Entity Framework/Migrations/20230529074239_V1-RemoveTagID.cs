using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS43___Migration_và_Scaffold_trong_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class V1RemoveTagID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "article",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "TagIdNew",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagIdNew");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagIdNew",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "article",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "TagId",
                table: "Tags",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");
        }
    }
}
