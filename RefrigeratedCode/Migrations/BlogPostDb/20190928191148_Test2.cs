using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RefrigeratedCode.Migrations.BlogPostDb
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditedOn",
                table: "BlogPosts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditedOn",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BlogPosts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                column: "Id");
        }
    }
}
