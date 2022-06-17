using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infra.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TODO_USERS_UserId",
                schema: "dbo",
                table: "TODO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TODO",
                schema: "dbo",
                table: "TODO");

            migrationBuilder.DropIndex(
                name: "IX_TODO_UserId",
                schema: "dbo",
                table: "TODO");

            migrationBuilder.RenameTable(
                name: "TODO",
                schema: "dbo",
                newName: "TODO_LIST",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "TodoId",
                schema: "dbo",
                table: "TODO_LIST",
                newName: "TodoListId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "TODO_LIST",
                newName: "Priority");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "TODO_LIST",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                schema: "dbo",
                table: "TODO_LIST",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "dbo",
                table: "TODO_LIST",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TODO_LIST",
                schema: "dbo",
                table: "TODO_LIST",
                column: "TodoListId");

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TODO_LIST_ListId",
                schema: "dbo",
                table: "TODO_LIST",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TODO_LIST_TodoList_ListId",
                schema: "dbo",
                table: "TODO_LIST",
                column: "ListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TODO_LIST_TodoList_ListId",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TODO_LIST",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropIndex(
                name: "IX_TODO_LIST_ListId",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropColumn(
                name: "ListId",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropColumn(
                name: "Note",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.RenameTable(
                name: "TODO_LIST",
                schema: "dbo",
                newName: "TODO",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "TodoListId",
                schema: "dbo",
                table: "TODO",
                newName: "TodoId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                schema: "dbo",
                table: "TODO",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "TODO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TODO",
                schema: "dbo",
                table: "TODO",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_TODO_UserId",
                schema: "dbo",
                table: "TODO",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TODO_USERS_UserId",
                schema: "dbo",
                table: "TODO",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "USERS",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
