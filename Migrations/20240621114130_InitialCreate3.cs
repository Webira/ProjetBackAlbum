using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetBackAlbum.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Tags_TagsId",
                table: "UserTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Users_UsersId",
                table: "UserTags");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserTags",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "UserTags",
                newName: "TagsTagId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTags_UsersId",
                table: "UserTags",
                newName: "IX_UserTags_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Photos",
                newName: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTags_Tags_TagsTagId",
                table: "UserTags",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTags_Users_UsersUserId",
                table: "UserTags",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Tags_TagsTagId",
                table: "UserTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Users_UsersUserId",
                table: "UserTags");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "UserTags",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "TagsTagId",
                table: "UserTags",
                newName: "TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTags_UsersUserId",
                table: "UserTags",
                newName: "IX_UserTags_UsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Photos",
                newName: "Id");

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
    }
}
