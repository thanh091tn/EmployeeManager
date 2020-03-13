using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updatenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserManage_User_ManagedBy",
                table: "UserManage");

            migrationBuilder.DropIndex(
                name: "IX_UserManage_ManagedBy",
                table: "UserManage");

            migrationBuilder.AlterColumn<string>(
                name: "ManagedBy",
                table: "UserManage",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ManagedBy",
                table: "UserManage",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserManage_ManagedBy",
                table: "UserManage",
                column: "ManagedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_UserManage_User_ManagedBy",
                table: "UserManage",
                column: "ManagedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
