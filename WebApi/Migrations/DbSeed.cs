using System;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Models.Entities;

namespace WebApi.Migrations
{
    public partial class DbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Title", "Content", "CreatedAt", "Author" },
                values: new object[] { 1, "post-1", "Contenu", new DateTime(), new AuthorEntity() });
 
//            migrationBuilder.InsertData(
//                table: "author",
//                columns: new[] { "CarId", "Make", "Model" },
//                values: new object[] { 2, "Ferrari", "F50" });
// 
//            migrationBuilder.InsertData(
//                table: "comments",
//                columns: new[] { "CarId", "Make", "Model" },
//                values: new object[] { 3, "Labourghini", "Countach" });
        }
    }
}