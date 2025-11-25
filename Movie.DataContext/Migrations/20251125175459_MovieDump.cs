using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class MovieDump : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Description", "Director", "PosterUrl", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 0.0, "Imprisoned in the 1940s for the double murder of his wife and her lover, upstanding banker Andy Dufresne begins a new life at the Shawshank prison, where he puts his accounting skills to work for an amoral warden. During his long stretch in prison, Dufresne comes to be admired by the other inmates -- including an older prisoner named Red -- for his integrity and unquenchable sense of hope.", "Frank Darabont", "https://image.tmdb.org/t/p/original/9cqNxx0GxF0bflZmeSMuL5tnGzr.jpg", 1994, "The Shawshank Redemption" },
                    { 2, 0.0, "Spanning the years 1945 to 1955, a chronicle of the fictional Italian-American Corleone crime family. When organized crime family patriarch, Vito Corleone barely survives an attempt on his life, his youngest son, Michael steps in to take care of the would-be killers, launching a campaign of bloody revenge.", "Francis Ford Coppola", "https://image.tmdb.org/t/p/original/3bhkrj58Vtu7enYsRolD1fZdja1.jpg", 1972, "The Godfather" },
                    { 3, 0.0, "Batman raises the stakes in his war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to dismantle the remaining criminal organizations that plague the streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as the Joker.", "Christopher Nolan", "https://image.tmdb.org/t/p/original/qJ2tW6WMUDux911r6m7haRef0WH.jpg", 2008, "The Dark Knight" },
                    { 4, 0.0, "A burger-loving hit man, his philosophical partner, a drug-addled gangster's moll and a washed-up boxer converge in this sprawling, comedic crime caper. Their adventures unfurl in three stories that ingeniously trip back and forth in time.", "Quentin Tarantino", "https://image.tmdb.org/t/p/original/vQWk5YBFWF4bZaofAbv0tShwBvQ.jpg", 1994, "Pulp Fiction" },
                    { 5, 0.0, "The true story of how businessman Oskar Schindler saved over a thousand Jewish lives from the Nazis while they worked as slaves in his factory during World War II.", "Steven Spielberg", "https://image.tmdb.org/t/p/original/sF1U4EUQS8YHUYjNl3pMGNIQyr0.jpg", 1993, "Schindler's List" },
                    { 6, 0.0, "As armies mass for a final battle that will decide the fate of the world--and powerful, ancient forces of Light and Dark compete to determine the outcome--one member of the Fellowship of the Ring is revealed as the noble heir to the throne of the Kings of Men...", "Peter Jackson", "https://image.tmdb.org/t/p/original/rCzpDGLbOoPwLjy3OAm5NUPOTrC.jpg", 2003, "The Lord of the Rings: The Return of the King" },
                    { 7, 0.0, "Young hobbit Frodo Baggins, after inheriting a mysterious ring from his uncle Bilbo, must leave his home in order to keep it from falling into the hands of its evil creator. Along the way, a fellowship is formed to protect the ringbearer and make sure that the ring arrives at its final destination.", "Peter Jackson", "https://image.tmdb.org/t/p/original/6oom5QYQ2yQTMJIbnvbkBL9cHo6.jpg", 2001, "The Lord of the Rings: The Fellowship of the Ring" },
                    { 8, 0.0, "Frodo Baggins and the other members of the Fellowship continue on their sacred quest to destroy the One Ring--but on separate paths...", "Peter Jackson", "https://image.tmdb.org/t/p/original/5VTN0pR8gcqV3EPUHHfMGnJYN9L.jpg", 2002, "The Lord of the Rings: The Two Towers" },
                    { 9, 0.0, "A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy...", "David Fincher", "https://image.tmdb.org/t/p/original/pB8BM7pdSp6B6Ih7QZ4DrQ3PmJK.jpg", 1999, "Fight Club" },
                    { 10, 0.0, "A man with a low IQ has accomplished great things in his life and been present during significant historic events—in each case, far exceeding what anyone imagined he could do. But despite all he has achieved, his one true love eludes him.", "Robert Zemeckis", "https://image.tmdb.org/t/p/original/saHP97rTPS5eLmrLQEcANmKrsFl.jpg", 1994, "Forrest Gump" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
