using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infra.Migrations
{
    public partial class UpdateEntitiesConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TODO_LIST_TodoList_ListId",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropIndex(
                name: "IX_TODO_LIST_ListId",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropColumn(
                name: "Done",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropColumn(
                name: "LimitDate",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropColumn(
                name: "ListId",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "dbo",
                table: "TODO_LIST");

            migrationBuilder.RenameColumn(
                name: "Note",
                schema: "dbo",
                table: "TODO_LIST",
                newName: "Colour");

            migrationBuilder.CreateTable(
                name: "TODO",
                schema: "dbo",
                columns: table => new
                {
                    TodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    LimitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODO", x => x.TodoId);
                    table.ForeignKey(
                        name: "FK_TODO_TODO_LIST_ListId",
                        column: x => x.ListId,
                        principalSchema: "dbo",
                        principalTable: "TODO_LIST",
                        principalColumn: "TodoListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TODO_ListId",
                schema: "dbo",
                table: "TODO",
                column: "ListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODO",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Colour",
                schema: "dbo",
                table: "TODO_LIST",
                newName: "Note");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                schema: "dbo",
                table: "TODO_LIST",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LimitDate",
                schema: "dbo",
                table: "TODO_LIST",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                schema: "dbo",
                table: "TODO_LIST",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "dbo",
                table: "TODO_LIST",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
