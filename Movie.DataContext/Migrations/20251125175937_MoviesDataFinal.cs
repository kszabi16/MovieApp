using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class MoviesDataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Description", "Director", "PosterUrl", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 11, 0.0, "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: inception, the implantation of another person's idea into a target's subconscious.", "Christopher Nolan", "https://image.tmdb.org/t/p/original/xlaY2zyzMfkhk0HSC5VUwzoZPU1.jpg", 2010, "Inception" },
                    { 12, 0.0, "Set in the 22nd century, The Matrix tells the story of a computer hacker who joins a group of underground insurgents fighting the vast and powerful computers who now rule the earth.", "Lana Wachowski", "https://image.tmdb.org/t/p/original/p96dm7sCMn4VYAStA6siNz30G1r.jpg", 1999, "The Matrix" },
                    { 13, 0.0, "The true story of Henry Hill, a half-Irish, half-Sicilian Brooklyn kid who is adopted by neighbourhood gangsters at an early age and climbs the ranks of a Mafia family under the guidance of Jimmy Conway.", "Martin Scorsese", "https://image.tmdb.org/t/p/original/aKuFiU82s5ISJpGZp7YkIr3kCUd.jpg", 1990, "GoodFellas" },
                    { 14, 0.0, "The epic saga continues as Luke Skywalker learns the ways of the Jedi from master Yoda while the rebellion faces the might of the Galactic Empire.", "Irvin Kershner", "https://image.tmdb.org/t/p/original/nNAeTmF4CtdSgMDplXTDPOpYzsX.jpg", 1980, "The Empire Strikes Back" },
                    { 15, 0.0, "Clarice Starling is a top student at the FBI academy. Jack Crawford wants her to interview Dr. Hannibal Lecter, a brilliant psychiatrist and cannibalistic serial killer, hoping he has insight into a related case.", "Jonathan Demme", "https://image.tmdb.org/t/p/original/uS9m8OBk1A8eM9I042bx8XXpqAq.jpg", 1991, "The Silence of the Lambs" },
                    { 16, 0.0, "Two homicide detectives are on a desperate hunt for a serial killer whose crimes are based on the seven deadly sins, unraveling a dark and disturbing string of murders.", "David Fincher", "https://image.tmdb.org/t/p/original/191nKfP0ehp3uIvWqgPbFmI4lv9.jpg", 1995, "Se7en" },
                    { 17, 0.0, "A group of explorers travel through a wormhole near Saturn in search of a new home for humanity as Earth becomes uninhabitable.", "Christopher Nolan", "https://image.tmdb.org/t/p/original/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg", 2014, "Interstellar" },
                    { 18, 0.0, "During WWII, a group of U.S. soldiers are sent behind enemy lines to retrieve a paratrooper whose brothers were killed in combat.", "Steven Spielberg", "https://image.tmdb.org/t/p/original/uqx37cS8cpHg8U35f9U5IBlrCV3.jpg", 1998, "Saving Private Ryan" },
                    { 19, 0.0, "A death row prison guard meets a mysterious inmate with a miraculous gift that changes the lives of those around him.", "Frank Darabont", "https://image.tmdb.org/t/p/original/o0lO84GI7qrG6XFvtsPOSV7CTNa.jpg", 1999, "The Green Mile" },
                    { 20, 0.0, "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.", "Ridley Scott", "https://image.tmdb.org/t/p/original/ty8TGRuvJLPUmAR1H1nRIsgwvim.jpg", 2000, "Gladiator" },
                    { 21, 0.0, "Young lion prince Simba, eager to one day become king, must confront his past and find his rightful place in the Circle of Life.", "Roger Allers", "https://image.tmdb.org/t/p/original/sKCr78MXSLixwmZ8DyJLrpMsd15.jpg", 1994, "The Lion King" },
                    { 22, 0.0, "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in Boston.", "Martin Scorsese", "https://image.tmdb.org/t/p/original/nT97ifVT2J1yMQmeq20Qblg61T.jpg", 2006, "The Departed" },
                    { 23, 0.0, "A talented young drummer enrolls at a music conservatory where he is mentored by an instructor known for his terrifying teaching methods.", "Damien Chazelle", "https://image.tmdb.org/t/p/original/7fn624j5lj3xTme2SgiLCeuedmO.jpg", 2014, "Whiplash" },
                    { 24, 0.0, "Two magicians' rivalry escalates into a dangerous battle filled with obsession, deception, and tragic consequences.", "Christopher Nolan", "https://image.tmdb.org/t/p/original/bdN3gXuIZYaJP7ftKK2sU0nPtEA.jpg", 2006, "The Prestige" },
                    { 25, 0.0, "A small-time con man spins a dark and twisted story about the legendary criminal mastermind Keyser Söze.", "Bryan Singer", "https://image.tmdb.org/t/p/original/99X2SgyFunJFXGAYnDv3sb9pnUD.jpg", 1995, "The Usual Suspects" },
                    { 26, 0.0, "The story of Polish Jewish musician Władysław Szpilman and his struggle to survive the destruction of the Warsaw ghetto.", "Roman Polanski", "https://image.tmdb.org/t/p/original/2hFvxCCWrTmCYwfy7yum0GKRi3Y.jpg", 2002, "The Pianist" },
                    { 27, 0.0, "A reprogrammed Terminator is sent back in time to protect John Connor from a more advanced and deadly machine.", "James Cameron", "https://image.tmdb.org/t/p/original/jFTVD4XoWQTcg7wdyJKa8PEds5q.jpg", 1991, "Terminator 2: Judgment Day" },
                    { 28, 0.0, "Teenager Marty McFly is accidentally sent back to 1955, disrupting his parents' first meeting and risking his own existence.", "Robert Zemeckis", "https://image.tmdb.org/t/p/original/vN5B5WgYscRGcQpVhHl6p9DDTP0.jpg", 1985, "Back to the Future" },
                    { 29, 0.0, "Batman returns after eight years in exile to face the masked terrorist Bane and save Gotham from destruction.", "Christopher Nolan", "https://image.tmdb.org/t/p/original/hr0L2aueqlP2BYUblTTjmtn0hw4.jpg", 2012, "The Dark Knight Rises" },
                    { 30, 0.0, "After his identity is revealed, Peter Parker seeks help from Doctor Strange, leading to multiverse-shattering consequences.", "Jon Watts", "https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg", 2021, "Spider-Man: No Way Home" },
                    { 31, 0.0, "After the devastating events of Infinity War, the remaining Avengers assemble once more to undo Thanos' actions and restore balance to the universe.", "Anthony Russo", "https://image.tmdb.org/t/p/original/bR8ISy1O9XQxqiy0fQFw2BX72RQ.jpg", 2019, "Avengers: Endgame" },
                    { 32, 0.0, "The Avengers and their allies must be willing to sacrifice everything as they face the powerful Thanos who aims to collect all six Infinity Stones.", "Joe Russo", "https://image.tmdb.org/t/p/original/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg", 2018, "Avengers: Infinity War" },
                    { 33, 0.0, "A freed slave teams up with a German bounty hunter to rescue his wife from a brutal Mississippi plantation owner.", "Quentin Tarantino", "https://image.tmdb.org/t/p/original/7oWY8VDWW7thTzWh3OKYRkWUlD5.jpg", 2012, "Django Unchained" },
                    { 34, 0.0, "A New York stockbroker rises to immense wealth through corruption and fraud, but his life spirals out of control as the FBI closes in.", "Martin Scorsese", "https://image.tmdb.org/t/p/original/kW9LmvYHAaS9iA0tHmZVq8hQYoq.jpg", 2013, "The Wolf of Wall Street" },
                    { 35, 0.0, "A U.S. Marshal investigates the disappearance of a patient from a mental institution, uncovering shocking and unsettling truths.", "Martin Scorsese", "https://image.tmdb.org/t/p/original/nrmXQ0zcZUL8jFLrakWc90IR8z9.jpg", 2010, "Shutter Island" },
                    { 36, 0.0, "An insurance salesman begins to suspect that his entire life is actually part of a meticulously crafted reality TV show.", "Peter Weir", "https://image.tmdb.org/t/p/original/vuza0WqY239yBXOadKlGwJsZJFE.jpg", 1998, "The Truman Show" },
                    { 37, 0.0, "Mark Zuckerberg creates a social networking site at Harvard that grows into Facebook, but personal and legal complications follow.", "David Fincher", "https://image.tmdb.org/t/p/original/n0ybibhJtQ5icDqTp8eRytcIHJx.jpg", 2010, "The Social Network" },
                    { 38, 0.0, "Bounty hunters seek refuge from a blizzard, but tensions rise as betrayal and deception unfold inside a remote cabin.", "Quentin Tarantino", "https://image.tmdb.org/t/p/original/jIywvdPjia2t3eKYbjVTcwBQlG8.jpg", 2015, "The Hateful Eight" },
                    { 39, 0.0, "A hunter stumbles across drug money, sparking a violent pursuit from a relentless and chilling hitman.", "Joel Coen", "https://image.tmdb.org/t/p/original/6d5XOczc226jECq0LIX0siKtgHR.jpg", 2007, "No Country for Old Men" },
                    { 40, 0.0, "A desperate family schemes to infiltrate the household of a wealthy family, leading to shocking consequences.", "Charles Band", "https://image.tmdb.org/t/p/original/4DGPORlVIDIQvsuSDnM4uXKMjWS.jpg", 1982, "Parasite" },
                    { 41, 0.0, "A mentally troubled comedian is driven to madness, sparking a violent revolution and becoming the infamous criminal mastermind known as the Joker.", "Todd Phillips", "https://image.tmdb.org/t/p/original/udDclJoHjfjb8Ekgsd4FDteOkCU.jpg", 2019, "Joker" },
                    { 42, 0.0, "In a post-apocalyptic wasteland, Max teams up with Furiosa to escape a tyrant and survive the brutal desert.", "George Miller", "https://image.tmdb.org/t/p/original/hA2ple9q4qnwxp3hKVNhroipsir.jpg", 2015, "Mad Max: Fury Road" },
                    { 43, 0.0, "A retired hitman seeks vengeance against the criminals who stole everything from him, unleashing pure, stylish mayhem.", "Chad Stahelski", "https://image.tmdb.org/t/p/original/fZPSd91yGE9fCcCe6OoQr6E3Bev.jpg", 2014, "John Wick" },
                    { 44, 0.0, "A paraplegic Marine is sent to the moon Pandora on a unique mission and becomes torn between following orders and protecting its alien inhabitants.", "James Cameron", "https://image.tmdb.org/t/p/original/gKY6q7SjCkAU6FqvqWybDYgUKIF.jpg", 2009, "Avatar" },
                    { 45, 0.0, "A frontiersman maimed by a bear fights for survival and hunts down those who betrayed him.", "Alejandro González Iñárritu", "https://image.tmdb.org/t/p/original/ji3ecJphATlVgWNY0B0RVXZizdf.jpg", 2015, "The Revenant" },
                    { 46, 0.0, "Stranded on Mars, astronaut Mark Watney must rely on his ingenuity to survive and signal to Earth that he is alive.", "Ridley Scott", "https://image.tmdb.org/t/p/original/3ndAx3weG6KDkJIRMCi5vXX6Dyb.jpg", 2015, "The Martian" },
                    { 47, 0.0, "A jazz musician and an aspiring actress fall in love while struggling to chase their dreams in Los Angeles.", "Damien Chazelle", "https://image.tmdb.org/t/p/original/uDO8zWDhfWwoFdKS4fzkUJt0Rf0.jpg", 2016, "La La Land" },
                    { 48, 0.0, "A theme park featuring living dinosaurs descends into chaos when the prehistoric creatures escape.", "Steven Spielberg", "https://image.tmdb.org/t/p/original/bRKmwU9eXZI5dKT11Zx1KsayiLW.jpg", 1993, "Jurassic Park" },
                    { 49, 0.0, "Five high school students in Saturday detention discover they have much more in common than they ever imagined.", "John Hughes", "https://image.tmdb.org/t/p/original/wM9ErA8UVdcce5P4oefQinN8VVV.jpg", 1985, "The Breakfast Club" },
                    { 50, 0.0, "Armies gather for the final battle of Middle-earth while Frodo and Sam journey toward Mount Doom to destroy the One Ring.", "Peter Jackson", "https://image.tmdb.org/t/p/original/rCzpDGLbOoPwLjy3OAm5NUPOTrC.jpg", 2003, "The Lord of the Rings: The Return of the King" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
