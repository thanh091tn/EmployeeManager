using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserManage_User_UserId",
                table: "UserManage");

            migrationBuilder.DropIndex(
                name: "IX_UserManage_UserId",
                table: "UserManage");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserManage",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ManagedBy",
                table: "UserManage",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserManage",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserManage_ManagedBy",
                table: "UserManage",
                column: "ManagedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserManage_GroupId",
                table: "User",
                column: "GroupId",
                principalTable: "UserManage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserManage_User_ManagedBy",
                table: "UserManage",
                column: "ManagedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserManage_GroupId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserManage_User_ManagedBy",
                table: "UserManage");

            migrationBuilder.DropIndex(
                name: "IX_UserManage_ManagedBy",
                table: "UserManage");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserManage",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ManagedBy",
                table: "UserManage",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserManage",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserManage_UserId",
                table: "UserManage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserManage_User_UserId",
                table: "UserManage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
