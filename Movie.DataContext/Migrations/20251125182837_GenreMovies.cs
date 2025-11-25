using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class GenreMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 7, 1 },
                    { 3, 2 },
                    { 7, 2 },
                    { 1, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 7, 4 },
                    { 3, 5 },
                    { 13, 5 },
                    { 14, 5 },
                    { 1, 6 },
                    { 6, 6 },
                    { 9, 6 },
                    { 1, 7 },
                    { 6, 7 },
                    { 9, 7 },
                    { 1, 8 },
                    { 6, 8 },
                    { 9, 8 },
                    { 3, 9 },
                    { 7, 9 },
                    { 8, 9 },
                    { 3, 10 },
                    { 11, 10 },
                    { 1, 11 },
                    { 4, 11 },
                    { 8, 11 },
                    { 1, 12 },
                    { 4, 12 },
                    { 3, 13 },
                    { 7, 13 },
                    { 1, 14 },
                    { 6, 14 },
                    { 9, 14 },
                    { 7, 15 },
                    { 8, 15 },
                    { 10, 15 },
                    { 7, 16 },
                    { 8, 16 },
                    { 10, 16 },
                    { 3, 17 },
                    { 4, 17 },
                    { 6, 17 },
                    { 1, 18 },
                    { 13, 18 },
                    { 14, 18 },
                    { 3, 19 },
                    { 5, 19 },
                    { 10, 19 },
                    { 1, 20 },
                    { 6, 20 },
                    { 14, 20 },
                    { 11, 21 },
                    { 12, 21 },
                    { 17, 21 },
                    { 3, 22 },
                    { 7, 22 },
                    { 8, 22 },
                    { 3, 23 },
                    { 15, 23 },
                    { 3, 24 },
                    { 8, 24 },
                    { 10, 24 },
                    { 7, 25 },
                    { 8, 25 },
                    { 10, 25 },
                    { 3, 26 },
                    { 13, 26 },
                    { 14, 26 },
                    { 1, 27 },
                    { 4, 27 },
                    { 2, 28 },
                    { 6, 28 },
                    { 11, 28 },
                    { 1, 29 },
                    { 7, 29 },
                    { 8, 29 },
                    { 1, 30 },
                    { 6, 30 },
                    { 9, 30 },
                    { 1, 31 },
                    { 6, 31 },
                    { 9, 31 },
                    { 1, 32 },
                    { 6, 32 },
                    { 9, 32 },
                    { 1, 33 },
                    { 7, 33 },
                    { 16, 33 },
                    { 2, 34 },
                    { 3, 34 },
                    { 7, 34 },
                    { 3, 35 },
                    { 8, 35 },
                    { 10, 35 },
                    { 2, 36 },
                    { 3, 36 },
                    { 3, 37 },
                    { 14, 37 },
                    { 3, 38 },
                    { 8, 38 },
                    { 16, 38 },
                    { 7, 39 },
                    { 8, 39 },
                    { 16, 39 },
                    { 3, 40 },
                    { 8, 40 },
                    { 3, 41 },
                    { 8, 41 },
                    { 1, 42 },
                    { 6, 42 },
                    { 1, 43 },
                    { 7, 43 },
                    { 4, 44 },
                    { 6, 44 },
                    { 9, 44 },
                    { 1, 45 },
                    { 3, 45 },
                    { 16, 45 },
                    { 4, 46 },
                    { 6, 46 },
                    { 3, 47 },
                    { 11, 47 },
                    { 15, 47 },
                    { 5, 48 },
                    { 6, 48 },
                    { 9, 48 },
                    { 2, 49 },
                    { 3, 49 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 14 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 10, 15 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 10, 16 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 13, 18 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 14, 18 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 19 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 10, 19 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 20 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 14, 20 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 11, 21 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 12, 21 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 17, 21 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 22 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 15, 23 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 24 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 10, 24 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 25 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 25 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 10, 25 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 13, 26 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 14, 26 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 27 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 28 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 11, 28 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 29 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 29 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 29 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 30 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 30 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 31 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 31 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 32 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 32 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 33 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 33 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 16, 33 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 2, 34 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 34 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 34 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 35 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 35 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 10, 35 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 2, 36 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 36 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 37 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 14, 37 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 38 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 38 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 16, 38 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 39 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 39 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 16, 39 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 40 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 40 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 41 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 41 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 42 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 42 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 43 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 43 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 44 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 44 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 44 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 45 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 45 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 16, 45 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 46 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 46 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 47 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 11, 47 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 15, 47 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 5, 48 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 48 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 9, 48 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 2, 49 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 49 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Description", "Director", "PosterUrl", "ReleaseYear", "Title" },
                values: new object[] { 50, 0.0, "Armies gather for the final battle of Middle-earth while Frodo and Sam journey toward Mount Doom to destroy the One Ring.", "Peter Jackson", "https://image.tmdb.org/t/p/original/rCzpDGLbOoPwLjy3OAm5NUPOTrC.jpg", 2003, "The Lord of the Rings: The Return of the King" });
        }
    }
}
