using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetBackAlbum.Migrations
{
    /// <inheritdoc />
    public partial class correctionmodel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tags_TagId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Photos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tags_TagId",
                table: "Posts",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tags_TagId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tags_TagId",
                table: "Posts",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
