using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace G_ASP_NET_83_EFCore3.Migrations
{
    /// <inheritdoc />
    public partial class SeedCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Learn C# from scratch", 1, true, 0, 500m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" },
                    { 2, 4, "Learn ASP.NET Core Web Development", 1, true, 1, 800m, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core" },
                    { 3, 3, "Mobile Development with Flutter", 2, true, 0, 600m, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flutter Basics" },
                    { 4, 3, "Advanced Mobile Development", 2, false, 2, 1000m, null, "Advanced Flutter" },
                    { 5, 5, "Learn SQL and Database Basics", 3, true, 0, 400m, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Fundamentals" },
                    { 6, 5, "Advanced Database Concepts", 3, false, 2, 900m, null, "Advanced Database" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
