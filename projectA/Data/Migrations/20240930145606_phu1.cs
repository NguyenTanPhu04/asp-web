using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectA.Data.Migrations
{
    /// <inheritdoc />
    public partial class phu1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TSanPham_TheLoai_TheLoaiId",
                table: "TSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSanPham",
                table: "TSanPham");

            migrationBuilder.RenameTable(
                name: "TSanPham",
                newName: "SanPham");

            migrationBuilder.RenameIndex(
                name: "IX_TSanPham_TheLoaiId",
                table: "SanPham",
                newName: "IX_SanPham_TheLoaiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaiId",
                table: "SanPham",
                column: "TheLoaiId",
                principalTable: "TheLoai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaiId",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "SanPham",
                newName: "TSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_TheLoaiId",
                table: "TSanPham",
                newName: "IX_TSanPham_TheLoaiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSanPham",
                table: "TSanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TSanPham_TheLoai_TheLoaiId",
                table: "TSanPham",
                column: "TheLoaiId",
                principalTable: "TheLoai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
