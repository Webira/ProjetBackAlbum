using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetBackAlbum.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagUser_Tags_TagsId",
                table: "TagUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TagUser_Users_UsersId",
                table: "TagUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagUser",
                table: "TagUser");

            migrationBuilder.RenameTable(
                name: "TagUser",
                newName: "UserTags");

            migrationBuilder.RenameIndex(
                name: "IX_TagUser_UsersId",
                table: "UserTags",
                newName: "IX_UserTags_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTags",
                table: "UserTags",
                columns: new[] { "TagsId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTags_Tags_TagsId",
                table: "UserTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTags_Users_UsersId",
                table: "UserTags",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Tags_TagsId",
                table: "UserTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Users_UsersId",
                table: "UserTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTags",
                table: "UserTags");

            migrationBuilder.RenameTable(
                name: "UserTags",
                newName: "TagUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserTags_UsersId",
                table: "TagUser",
                newName: "IX_TagUser_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagUser",
                table: "TagUser",
                columns: new[] { "TagsId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TagUser_Tags_TagsId",
                table: "TagUser",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagUser_Users_UsersId",
                table: "TagUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
