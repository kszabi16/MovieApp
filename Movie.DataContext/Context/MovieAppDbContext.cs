using MovieApp.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Context
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<MovieGenre> MovieGenres { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Favorite> Favorites { get; set; } = null!;
        public DbSet<ViewHistory> ViewHistory { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- User ---
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // --- MovieGenre (n-n kapcsolat) ---
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            // --- Rating ---
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Favorite ---
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(f => f.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- ViewHistory ---
            modelBuilder.Entity<ViewHistory>()
                .HasOne(v => v.User)
                .WithMany(u => u.ViewHistory)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ViewHistory>()
                .HasOne(v => v.Movie)
                .WithMany(m => m.ViewHistory)
                .HasForeignKey(v => v.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Genre név unique ---
            modelBuilder.Entity<Genre>()
                .HasIndex(g => g.Name)
                .IsUnique();

            // --- Alap adatok (opcionális seed) ---
            modelBuilder.Entity<Genre>().HasData(
    new Genre { Id = 1, Name = "Action" },
    new Genre { Id = 2, Name = "Comedy" },
    new Genre { Id = 3, Name = "Drama" },
    new Genre { Id = 4, Name = "Sci-Fi" },
    new Genre { Id = 5, Name = "Horror" },
    new Genre { Id = 6, Name = "Adventure" },
    new Genre { Id = 7, Name = "Crime" },
    new Genre { Id = 8, Name = "Thriller" },
    new Genre { Id = 9, Name = "Fantasy" },
    new Genre { Id = 10, Name = "Mystery" },
    new Genre { Id = 11, Name = "Romance" },
    new Genre { Id = 12, Name = "Animation" },
    new Genre { Id = 13, Name = "War" },
    new Genre { Id = 14, Name = "History" },
    new Genre { Id = 15, Name = "Music" },
    new Genre { Id = 16, Name = "Western" },
    new Genre { Id = 17, Name = "Family" }
);

            modelBuilder.Entity<Movie>().HasData(
    new Movie
    {
        Id = 1,
        Title = "The Shawshank Redemption",
        Description = "Imprisoned in the 1940s for the double murder of his wife and her lover, upstanding banker Andy Dufresne begins a new life at the Shawshank prison, where he puts his accounting skills to work for an amoral warden. During his long stretch in prison, Dufresne comes to be admired by the other inmates -- including an older prisoner named Red -- for his integrity and unquenchable sense of hope.",
        ReleaseYear = 1994,
        PosterUrl = "https://image.tmdb.org/t/p/original/9cqNxx0GxF0bflZmeSMuL5tnGzr.jpg",
        AverageRating = 0,
        Director = "Frank Darabont"
    },
    new Movie
    {
        Id = 2,
        Title = "The Godfather",
        Description = "Spanning the years 1945 to 1955, a chronicle of the fictional Italian-American Corleone crime family. When organized crime family patriarch, Vito Corleone barely survives an attempt on his life, his youngest son, Michael steps in to take care of the would-be killers, launching a campaign of bloody revenge.",
        ReleaseYear = 1972,
        PosterUrl = "https://image.tmdb.org/t/p/original/3bhkrj58Vtu7enYsRolD1fZdja1.jpg",
        AverageRating = 0,
        Director = "Francis Ford Coppola"
    },
    new Movie
    {
        Id = 3,
        Title = "The Dark Knight",
        Description = "Batman raises the stakes in his war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to dismantle the remaining criminal organizations that plague the streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as the Joker.",
        ReleaseYear = 2008,
        PosterUrl = "https://image.tmdb.org/t/p/original/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
        AverageRating = 0,
        Director = "Christopher Nolan"
    },
    new Movie
    {
        Id = 4,
        Title = "Pulp Fiction",
        Description = "A burger-loving hit man, his philosophical partner, a drug-addled gangster's moll and a washed-up boxer converge in this sprawling, comedic crime caper. Their adventures unfurl in three stories that ingeniously trip back and forth in time.",
        ReleaseYear = 1994,
        PosterUrl = "https://image.tmdb.org/t/p/original/vQWk5YBFWF4bZaofAbv0tShwBvQ.jpg",
        AverageRating = 0,
        Director = "Quentin Tarantino"
    },
    new Movie
    {
        Id = 5,
        Title = "Schindler's List",
        Description = "The true story of how businessman Oskar Schindler saved over a thousand Jewish lives from the Nazis while they worked as slaves in his factory during World War II.",
        ReleaseYear = 1993,
        PosterUrl = "https://image.tmdb.org/t/p/original/sF1U4EUQS8YHUYjNl3pMGNIQyr0.jpg",
        AverageRating = 0,
        Director = "Steven Spielberg"
    },
    new Movie
    {
        Id = 6,
        Title = "The Lord of the Rings: The Return of the King",
        Description = "As armies mass for a final battle that will decide the fate of the world--and powerful, ancient forces of Light and Dark compete to determine the outcome--one member of the Fellowship of the Ring is revealed as the noble heir to the throne of the Kings of Men...",
        ReleaseYear = 2003,
        PosterUrl = "https://image.tmdb.org/t/p/original/rCzpDGLbOoPwLjy3OAm5NUPOTrC.jpg",
        AverageRating = 0,
        Director = "Peter Jackson"
    },
    new Movie
    {
        Id = 7,
        Title = "The Lord of the Rings: The Fellowship of the Ring",
        Description = "Young hobbit Frodo Baggins, after inheriting a mysterious ring from his uncle Bilbo, must leave his home in order to keep it from falling into the hands of its evil creator. Along the way, a fellowship is formed to protect the ringbearer and make sure that the ring arrives at its final destination.",
        ReleaseYear = 2001,
        PosterUrl = "https://image.tmdb.org/t/p/original/6oom5QYQ2yQTMJIbnvbkBL9cHo6.jpg",
        AverageRating = 0,
        Director = "Peter Jackson"
    },
    new Movie
    {
        Id = 8,
        Title = "The Lord of the Rings: The Two Towers",
        Description = "Frodo Baggins and the other members of the Fellowship continue on their sacred quest to destroy the One Ring--but on separate paths...",
        ReleaseYear = 2002,
        PosterUrl = "https://image.tmdb.org/t/p/original/5VTN0pR8gcqV3EPUHHfMGnJYN9L.jpg",
        AverageRating = 0,
        Director = "Peter Jackson"
    },
    new Movie
    {
        Id = 9,
        Title = "Fight Club",
        Description = "A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy...",
        ReleaseYear = 1999,
        PosterUrl = "https://image.tmdb.org/t/p/original/pB8BM7pdSp6B6Ih7QZ4DrQ3PmJK.jpg",
        AverageRating = 0,
        Director = "David Fincher"
    },
    new Movie
    {
        Id = 10,
        Title = "Forrest Gump",
        Description = "A man with a low IQ has accomplished great things in his life and been present during significant historic events—in each case, far exceeding what anyone imagined he could do. But despite all he has achieved, his one true love eludes him.",
        ReleaseYear = 1994,
        PosterUrl = "https://image.tmdb.org/t/p/original/saHP97rTPS5eLmrLQEcANmKrsFl.jpg",
        AverageRating = 0,
        Director = "Robert Zemeckis"
    },
    new Movie
    {
        Id = 11,
        Title = "Inception",
        Description = "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: inception, the implantation of another person's idea into a target's subconscious.",
        ReleaseYear = 2010,
        PosterUrl = "https://image.tmdb.org/t/p/original/xlaY2zyzMfkhk0HSC5VUwzoZPU1.jpg",
        AverageRating = 0,
        Director = "Christopher Nolan"
    },
    new Movie
    {
        Id = 12,
        Title = "The Matrix",
        Description = "Set in the 22nd century, The Matrix tells the story of a computer hacker who joins a group of underground insurgents fighting the vast and powerful computers who now rule the earth.",
        ReleaseYear = 1999,
        PosterUrl = "https://image.tmdb.org/t/p/original/p96dm7sCMn4VYAStA6siNz30G1r.jpg",
        AverageRating = 0,
        Director = "Lana Wachowski"
    },
    new Movie
    {
        Id = 13,
        Title = "GoodFellas",
        Description = "The true story of Henry Hill, a half-Irish, half-Sicilian Brooklyn kid who is adopted by neighbourhood gangsters at an early age and climbs the ranks of a Mafia family under the guidance of Jimmy Conway.",
        ReleaseYear = 1990,
        PosterUrl = "https://image.tmdb.org/t/p/original/aKuFiU82s5ISJpGZp7YkIr3kCUd.jpg",
        AverageRating = 0,
        Director = "Martin Scorsese"
    },
    new Movie
    {
        Id = 14,
        Title = "The Empire Strikes Back",
        Description = "The epic saga continues as Luke Skywalker learns the ways of the Jedi from master Yoda while the rebellion faces the might of the Galactic Empire.",
        ReleaseYear = 1980,
        PosterUrl = "https://image.tmdb.org/t/p/original/nNAeTmF4CtdSgMDplXTDPOpYzsX.jpg",
        AverageRating = 0,
        Director = "Irvin Kershner"
    },
    new Movie
    {
        Id = 15,
        Title = "The Silence of the Lambs",
        Description = "Clarice Starling is a top student at the FBI academy. Jack Crawford wants her to interview Dr. Hannibal Lecter, a brilliant psychiatrist and cannibalistic serial killer, hoping he has insight into a related case.",
        ReleaseYear = 1991,
        PosterUrl = "https://image.tmdb.org/t/p/original/uS9m8OBk1A8eM9I042bx8XXpqAq.jpg",
        AverageRating = 0,
        Director = "Jonathan Demme"
    },
    new Movie
    {
        Id = 16,
        Title = "Se7en",
        Description = "Two homicide detectives are on a desperate hunt for a serial killer whose crimes are based on the seven deadly sins, unraveling a dark and disturbing string of murders.",
        ReleaseYear = 1995,
        PosterUrl = "https://image.tmdb.org/t/p/original/191nKfP0ehp3uIvWqgPbFmI4lv9.jpg",
        AverageRating = 0,
        Director = "David Fincher"
    },
    new Movie
    {
        Id = 17,
        Title = "Interstellar",
        Description = "A group of explorers travel through a wormhole near Saturn in search of a new home for humanity as Earth becomes uninhabitable.",
        ReleaseYear = 2014,
        PosterUrl = "https://image.tmdb.org/t/p/original/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
        AverageRating = 0,
        Director = "Christopher Nolan"
    },
    new Movie
    {
        Id = 18,
        Title = "Saving Private Ryan",
        Description = "During WWII, a group of U.S. soldiers are sent behind enemy lines to retrieve a paratrooper whose brothers were killed in combat.",
        ReleaseYear = 1998,
        PosterUrl = "https://image.tmdb.org/t/p/original/uqx37cS8cpHg8U35f9U5IBlrCV3.jpg",
        AverageRating = 0,
        Director = "Steven Spielberg"
    },
    new Movie
    {
        Id = 19,
        Title = "The Green Mile",
        Description = "A death row prison guard meets a mysterious inmate with a miraculous gift that changes the lives of those around him.",
        ReleaseYear = 1999,
        PosterUrl = "https://image.tmdb.org/t/p/original/o0lO84GI7qrG6XFvtsPOSV7CTNa.jpg",
        AverageRating = 0,
        Director = "Frank Darabont"
    },
    new Movie
    {
        Id = 20,
        Title = "Gladiator",
        Description = "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.",
        ReleaseYear = 2000,
        PosterUrl = "https://image.tmdb.org/t/p/original/ty8TGRuvJLPUmAR1H1nRIsgwvim.jpg",
        AverageRating = 0,
        Director = "Ridley Scott"
    },
    new Movie
    {
        Id = 21,
        Title = "The Lion King",
        Description = "Young lion prince Simba, eager to one day become king, must confront his past and find his rightful place in the Circle of Life.",
        ReleaseYear = 1994,
        PosterUrl = "https://image.tmdb.org/t/p/original/sKCr78MXSLixwmZ8DyJLrpMsd15.jpg",
        AverageRating = 0,
        Director = "Roger Allers"
    },
    new Movie
    {
        Id = 22,
        Title = "The Departed",
        Description = "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in Boston.",
        ReleaseYear = 2006,
        PosterUrl = "https://image.tmdb.org/t/p/original/nT97ifVT2J1yMQmeq20Qblg61T.jpg",
        AverageRating = 0,
        Director = "Martin Scorsese"
    },
    new Movie
    {
        Id = 23,
        Title = "Whiplash",
        Description = "A talented young drummer enrolls at a music conservatory where he is mentored by an instructor known for his terrifying teaching methods.",
        ReleaseYear = 2014,
        PosterUrl = "https://image.tmdb.org/t/p/original/7fn624j5lj3xTme2SgiLCeuedmO.jpg",
        AverageRating = 0,
        Director = "Damien Chazelle"
    },
    new Movie
    {
        Id = 24,
        Title = "The Prestige",
        Description = "Two magicians' rivalry escalates into a dangerous battle filled with obsession, deception, and tragic consequences.",
        ReleaseYear = 2006,
        PosterUrl = "https://image.tmdb.org/t/p/original/bdN3gXuIZYaJP7ftKK2sU0nPtEA.jpg",
        AverageRating = 0,
        Director = "Christopher Nolan"
    },
    new Movie
    {
        Id = 25,
        Title = "The Usual Suspects",
        Description = "A small-time con man spins a dark and twisted story about the legendary criminal mastermind Keyser Söze.",
        ReleaseYear = 1995,
        PosterUrl = "https://image.tmdb.org/t/p/original/99X2SgyFunJFXGAYnDv3sb9pnUD.jpg",
        AverageRating = 0,
        Director = "Bryan Singer"
    },
    new Movie
    {
        Id = 26,
        Title = "The Pianist",
        Description = "The story of Polish Jewish musician Władysław Szpilman and his struggle to survive the destruction of the Warsaw ghetto.",
        ReleaseYear = 2002,
        PosterUrl = "https://image.tmdb.org/t/p/original/2hFvxCCWrTmCYwfy7yum0GKRi3Y.jpg",
        AverageRating = 0,
        Director = "Roman Polanski"
    },
    new Movie
    {
        Id = 27,
        Title = "Terminator 2: Judgment Day",
        Description = "A reprogrammed Terminator is sent back in time to protect John Connor from a more advanced and deadly machine.",
        ReleaseYear = 1991,
        PosterUrl = "https://image.tmdb.org/t/p/original/jFTVD4XoWQTcg7wdyJKa8PEds5q.jpg",
        AverageRating = 0,
        Director = "James Cameron"
    },
    new Movie
    {
        Id = 28,
        Title = "Back to the Future",
        Description = "Teenager Marty McFly is accidentally sent back to 1955, disrupting his parents' first meeting and risking his own existence.",
        ReleaseYear = 1985,
        PosterUrl = "https://image.tmdb.org/t/p/original/vN5B5WgYscRGcQpVhHl6p9DDTP0.jpg",
        AverageRating = 0,
        Director = "Robert Zemeckis"
    },
    new Movie
    {
        Id = 29,
        Title = "The Dark Knight Rises",
        Description = "Batman returns after eight years in exile to face the masked terrorist Bane and save Gotham from destruction.",
        ReleaseYear = 2012,
        PosterUrl = "https://image.tmdb.org/t/p/original/hr0L2aueqlP2BYUblTTjmtn0hw4.jpg",
        AverageRating = 0,
        Director = "Christopher Nolan"
    },
    new Movie
    {
        Id = 30,
        Title = "Spider-Man: No Way Home",
        Description = "After his identity is revealed, Peter Parker seeks help from Doctor Strange, leading to multiverse-shattering consequences.",
        ReleaseYear = 2021,
        PosterUrl = "https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg",
        AverageRating = 0,
        Director = "Jon Watts"
    },
     new Movie
     {
         Id = 31,
         Title = "Avengers: Endgame",
         Description = "After the devastating events of Infinity War, the remaining Avengers assemble once more to undo Thanos' actions and restore balance to the universe.",
         ReleaseYear = 2019,
         PosterUrl = "https://image.tmdb.org/t/p/original/bR8ISy1O9XQxqiy0fQFw2BX72RQ.jpg",
         AverageRating = 0,
         Director = "Anthony Russo"
     },
    new Movie
    {
        Id = 32,
        Title = "Avengers: Infinity War",
        Description = "The Avengers and their allies must be willing to sacrifice everything as they face the powerful Thanos who aims to collect all six Infinity Stones.",
        ReleaseYear = 2018,
        PosterUrl = "https://image.tmdb.org/t/p/original/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg",
        AverageRating = 0,
        Director = "Joe Russo"
    },
    new Movie
    {
        Id = 33,
        Title = "Django Unchained",
        Description = "A freed slave teams up with a German bounty hunter to rescue his wife from a brutal Mississippi plantation owner.",
        ReleaseYear = 2012,
        PosterUrl = "https://image.tmdb.org/t/p/original/7oWY8VDWW7thTzWh3OKYRkWUlD5.jpg",
        AverageRating = 0,
        Director = "Quentin Tarantino"
    },
    new Movie
    {
        Id = 34,
        Title = "The Wolf of Wall Street",
        Description = "A New York stockbroker rises to immense wealth through corruption and fraud, but his life spirals out of control as the FBI closes in.",
        ReleaseYear = 2013,
        PosterUrl = "https://image.tmdb.org/t/p/original/kW9LmvYHAaS9iA0tHmZVq8hQYoq.jpg",
        AverageRating = 0,
        Director = "Martin Scorsese"
    },
    new Movie
    {
        Id = 35,
        Title = "Shutter Island",
        Description = "A U.S. Marshal investigates the disappearance of a patient from a mental institution, uncovering shocking and unsettling truths.",
        ReleaseYear = 2010,
        PosterUrl = "https://image.tmdb.org/t/p/original/nrmXQ0zcZUL8jFLrakWc90IR8z9.jpg",
        AverageRating = 0,
        Director = "Martin Scorsese"
    },
    new Movie
    {
        Id = 36,
        Title = "The Truman Show",
        Description = "An insurance salesman begins to suspect that his entire life is actually part of a meticulously crafted reality TV show.",
        ReleaseYear = 1998,
        PosterUrl = "https://image.tmdb.org/t/p/original/vuza0WqY239yBXOadKlGwJsZJFE.jpg",
        AverageRating = 0,
        Director = "Peter Weir"
    },
    new Movie
    {
        Id = 37,
        Title = "The Social Network",
        Description = "Mark Zuckerberg creates a social networking site at Harvard that grows into Facebook, but personal and legal complications follow.",
        ReleaseYear = 2010,
        PosterUrl = "https://image.tmdb.org/t/p/original/n0ybibhJtQ5icDqTp8eRytcIHJx.jpg",
        AverageRating = 0,
        Director = "David Fincher"
    },
    new Movie
    {
        Id = 38,
        Title = "The Hateful Eight",
        Description = "Bounty hunters seek refuge from a blizzard, but tensions rise as betrayal and deception unfold inside a remote cabin.",
        ReleaseYear = 2015,
        PosterUrl = "https://image.tmdb.org/t/p/original/jIywvdPjia2t3eKYbjVTcwBQlG8.jpg",
        AverageRating = 0,
        Director = "Quentin Tarantino"
    },
    new Movie
    {
        Id = 39,
        Title = "No Country for Old Men",
        Description = "A hunter stumbles across drug money, sparking a violent pursuit from a relentless and chilling hitman.",
        ReleaseYear = 2007,
        PosterUrl = "https://image.tmdb.org/t/p/original/6d5XOczc226jECq0LIX0siKtgHR.jpg",
        AverageRating = 0,
        Director = "Joel Coen"
    },
    new Movie
    {
        Id = 40,
        Title = "Parasite",
        Description = "A desperate family schemes to infiltrate the household of a wealthy family, leading to shocking consequences.",
        ReleaseYear = 1982,
        PosterUrl = "https://image.tmdb.org/t/p/original/4DGPORlVIDIQvsuSDnM4uXKMjWS.jpg",
        AverageRating = 0,
        Director = "Charles Band"
    },
     new Movie
     {
         Id = 41,
         Title = "Joker",
         Description = "A mentally troubled comedian is driven to madness, sparking a violent revolution and becoming the infamous criminal mastermind known as the Joker.",
         ReleaseYear = 2019,
         PosterUrl = "https://image.tmdb.org/t/p/original/udDclJoHjfjb8Ekgsd4FDteOkCU.jpg",
         AverageRating = 0,
         Director = "Todd Phillips"
     },
    new Movie
    {
        Id = 42,
        Title = "Mad Max: Fury Road",
        Description = "In a post-apocalyptic wasteland, Max teams up with Furiosa to escape a tyrant and survive the brutal desert.",
        ReleaseYear = 2015,
        PosterUrl = "https://image.tmdb.org/t/p/original/hA2ple9q4qnwxp3hKVNhroipsir.jpg",
        AverageRating = 0,
        Director = "George Miller"
    },
    new Movie
    {
        Id = 43,
        Title = "John Wick",
        Description = "A retired hitman seeks vengeance against the criminals who stole everything from him, unleashing pure, stylish mayhem.",
        ReleaseYear = 2014,
        PosterUrl = "https://image.tmdb.org/t/p/original/fZPSd91yGE9fCcCe6OoQr6E3Bev.jpg",
        AverageRating = 0,
        Director = "Chad Stahelski"
    },
    new Movie
    {
        Id = 44,
        Title = "Avatar",
        Description = "A paraplegic Marine is sent to the moon Pandora on a unique mission and becomes torn between following orders and protecting its alien inhabitants.",
        ReleaseYear = 2009,
        PosterUrl = "https://image.tmdb.org/t/p/original/gKY6q7SjCkAU6FqvqWybDYgUKIF.jpg",
        AverageRating = 0,
        Director = "James Cameron"
    },
    new Movie
    {
        Id = 45,
        Title = "The Revenant",
        Description = "A frontiersman maimed by a bear fights for survival and hunts down those who betrayed him.",
        ReleaseYear = 2015,
        PosterUrl = "https://image.tmdb.org/t/p/original/ji3ecJphATlVgWNY0B0RVXZizdf.jpg",
        AverageRating = 0,
        Director = "Alejandro González Iñárritu"
    },
    new Movie
    {
        Id = 46,
        Title = "The Martian",
        Description = "Stranded on Mars, astronaut Mark Watney must rely on his ingenuity to survive and signal to Earth that he is alive.",
        ReleaseYear = 2015,
        PosterUrl = "https://image.tmdb.org/t/p/original/3ndAx3weG6KDkJIRMCi5vXX6Dyb.jpg",
        AverageRating = 0,
        Director = "Ridley Scott"
    },
    new Movie
    {
        Id = 47,
        Title = "La La Land",
        Description = "A jazz musician and an aspiring actress fall in love while struggling to chase their dreams in Los Angeles.",
        ReleaseYear = 2016,
        PosterUrl = "https://image.tmdb.org/t/p/original/uDO8zWDhfWwoFdKS4fzkUJt0Rf0.jpg",
        AverageRating = 0,
        Director = "Damien Chazelle"
    },
    new Movie
    {
        Id = 48,
        Title = "Jurassic Park",
        Description = "A theme park featuring living dinosaurs descends into chaos when the prehistoric creatures escape.",
        ReleaseYear = 1993,
        PosterUrl = "https://image.tmdb.org/t/p/original/bRKmwU9eXZI5dKT11Zx1KsayiLW.jpg",
        AverageRating = 0,
        Director = "Steven Spielberg"
    },
    new Movie
    {
        Id = 49,
        Title = "The Breakfast Club",
        Description = "Five high school students in Saturday detention discover they have much more in common than they ever imagined.",
        ReleaseYear = 1985,
        PosterUrl = "https://image.tmdb.org/t/p/original/wM9ErA8UVdcce5P4oefQinN8VVV.jpg",
        AverageRating = 0,
        Director = "John Hughes"
    }
);
            modelBuilder.Entity<MovieGenre>().HasData(
    // 1. Shawshank Redemption
    new { MovieId = 1, GenreId = 3 },
    new { MovieId = 1, GenreId = 7 },

    // 2. The Godfather
    new { MovieId = 2, GenreId = 7 },
    new { MovieId = 2, GenreId = 3 },

    // 3. The Dark Knight
    new { MovieId = 3, GenreId = 1 },
    new { MovieId = 3, GenreId = 7 },
    new { MovieId = 3, GenreId = 8 },

    // 4. Pulp Fiction
    new { MovieId = 4, GenreId = 7 },
    new { MovieId = 4, GenreId = 3 },
    new { MovieId = 4, GenreId = 1 },

    // 5. Schindler's List
    new { MovieId = 5, GenreId = 14 },
    new { MovieId = 5, GenreId = 3 },
    new { MovieId = 5, GenreId = 13 },

    // 6. LOTR: Return of the King
    new { MovieId = 6, GenreId = 6 },
    new { MovieId = 6, GenreId = 9 },
    new { MovieId = 6, GenreId = 1 },

    // 7. LOTR: Fellowship
    new { MovieId = 7, GenreId = 6 },
    new { MovieId = 7, GenreId = 9 },
    new { MovieId = 7, GenreId = 1 },

    // 8. LOTR: Two Towers
    new { MovieId = 8, GenreId = 6 },
    new { MovieId = 8, GenreId = 9 },
    new { MovieId = 8, GenreId = 1 },

    // 9. Fight Club
    new { MovieId = 9, GenreId = 8 },
    new { MovieId = 9, GenreId = 3 },
    new { MovieId = 9, GenreId = 7 },

    // 10. Forrest Gump
    new { MovieId = 10, GenreId = 3 },
    new { MovieId = 10, GenreId = 11 },

    // 11. Inception
    new { MovieId = 11, GenreId = 4 },
    new { MovieId = 11, GenreId = 8 },
    new { MovieId = 11, GenreId = 1 },

    // 12. The Matrix
    new { MovieId = 12, GenreId = 4 },
    new { MovieId = 12, GenreId = 1 },

    // 13. Goodfellas
    new { MovieId = 13, GenreId = 7 },
    new { MovieId = 13, GenreId = 3 },

    // 14. Empire Strikes Back
    new { MovieId = 14, GenreId = 6 },
    new { MovieId = 14, GenreId = 9 },
    new { MovieId = 14, GenreId = 1 },

    // 15. Silence of the Lambs
    new { MovieId = 15, GenreId = 8 },
    new { MovieId = 15, GenreId = 10 },
    new { MovieId = 15, GenreId = 7 },

    // 16. Se7en
    new { MovieId = 16, GenreId = 8 },
    new { MovieId = 16, GenreId = 10 },
    new { MovieId = 16, GenreId = 7 },

    // 17. Interstellar
    new { MovieId = 17, GenreId = 4 },
    new { MovieId = 17, GenreId = 6 },
    new { MovieId = 17, GenreId = 3 },

    // 18. Saving Private Ryan
    new { MovieId = 18, GenreId = 13 },
    new { MovieId = 18, GenreId = 14 },
    new { MovieId = 18, GenreId = 1 },

    // 19. The Green Mile
    new { MovieId = 19, GenreId = 3 },
    new { MovieId = 19, GenreId = 10 },
    new { MovieId = 19, GenreId = 5 },

    // 20. Gladiator
    new { MovieId = 20, GenreId = 1 },
    new { MovieId = 20, GenreId = 6 },
    new { MovieId = 20, GenreId = 14 },

    // 21. The Lion King
    new { MovieId = 21, GenreId = 17 },
    new { MovieId = 21, GenreId = 12 },
    new { MovieId = 21, GenreId = 11 },

    // 22. The Departed
    new { MovieId = 22, GenreId = 7 },
    new { MovieId = 22, GenreId = 8 },
    new { MovieId = 22, GenreId = 3 },

    // 23. Whiplash
    new { MovieId = 23, GenreId = 15 },
    new { MovieId = 23, GenreId = 3 },

    // 24. The Prestige
    new { MovieId = 24, GenreId = 8 },
    new { MovieId = 24, GenreId = 10 },
    new { MovieId = 24, GenreId = 3 },

    // 25. Usual Suspects
    new { MovieId = 25, GenreId = 7 },
    new { MovieId = 25, GenreId = 8 },
    new { MovieId = 25, GenreId = 10 },

    // 26. The Pianist
    new { MovieId = 26, GenreId = 14 },
    new { MovieId = 26, GenreId = 3 },
    new { MovieId = 26, GenreId = 13 },

    // 27. Terminator 2
    new { MovieId = 27, GenreId = 1 },
    new { MovieId = 27, GenreId = 4 },

    // 28. Back to the Future
    new { MovieId = 28, GenreId = 6 },
    new { MovieId = 28, GenreId = 11 },
    new { MovieId = 28, GenreId = 2 },

    // 29. Dark Knight Rises
    new { MovieId = 29, GenreId = 1 },
    new { MovieId = 29, GenreId = 7 },
    new { MovieId = 29, GenreId = 8 },

    // 30. Spider-Man: No Way Home
    new { MovieId = 30, GenreId = 1 },
    new { MovieId = 30, GenreId = 6 },
    new { MovieId = 30, GenreId = 9 },

    // 31. Endgame
    new { MovieId = 31, GenreId = 1 },
    new { MovieId = 31, GenreId = 6 },
    new { MovieId = 31, GenreId = 9 },

    // 32. Infinity War
    new { MovieId = 32, GenreId = 1 },
    new { MovieId = 32, GenreId = 6 },
    new { MovieId = 32, GenreId = 9 },

    // 33. Django
    new { MovieId = 33, GenreId = 1 },
    new { MovieId = 33, GenreId = 16 },
    new { MovieId = 33, GenreId = 7 },

    // 34. Wolf of Wall Street
    new { MovieId = 34, GenreId = 3 },
    new { MovieId = 34, GenreId = 2 },
    new { MovieId = 34, GenreId = 7 },

    // 35. Shutter Island
    new { MovieId = 35, GenreId = 8 },
    new { MovieId = 35, GenreId = 10 },
    new { MovieId = 35, GenreId = 3 },

    // 36. Truman Show
    new { MovieId = 36, GenreId = 3 },
    new { MovieId = 36, GenreId = 2 },

    // 37. Social Network
    new { MovieId = 37, GenreId = 3 },
    new { MovieId = 37, GenreId = 14 },

    // 38. Hateful Eight
    new { MovieId = 38, GenreId = 16 },
    new { MovieId = 38, GenreId = 3 },
    new { MovieId = 38, GenreId = 8 },

    // 39. No Country for Old Men
    new { MovieId = 39, GenreId = 16 },
    new { MovieId = 39, GenreId = 7 },
    new { MovieId = 39, GenreId = 8 },

    // 40. Parasite
    new { MovieId = 40, GenreId = 3 },
    new { MovieId = 40, GenreId = 8 },

    // 41. Joker
    new { MovieId = 41, GenreId = 3 },
    new { MovieId = 41, GenreId = 8 },

    // 42. Mad Max
    new { MovieId = 42, GenreId = 1 },
    new { MovieId = 42, GenreId = 6 },

    // 43. John Wick
    new { MovieId = 43, GenreId = 1 },
    new { MovieId = 43, GenreId = 7 },

    // 44. Avatar
    new { MovieId = 44, GenreId = 4 },
    new { MovieId = 44, GenreId = 6 },
    new { MovieId = 44, GenreId = 9 },

    // 45. The Revenant
    new { MovieId = 45, GenreId = 16 },
    new { MovieId = 45, GenreId = 1 },
    new { MovieId = 45, GenreId = 3 },

    // 46. The Martian
    new { MovieId = 46, GenreId = 4 },
    new { MovieId = 46, GenreId = 6 },

    // 47. La La Land
    new { MovieId = 47, GenreId = 11 },
    new { MovieId = 47, GenreId = 15 },
    new { MovieId = 47, GenreId = 3 },

    // 48. Jurassic Park
    new { MovieId = 48, GenreId = 6 },
    new { MovieId = 48, GenreId = 5 },
    new { MovieId = 48, GenreId = 9 },

    // 49. Breakfast Club
    new { MovieId = 49, GenreId = 3 },
    new { MovieId = 49, GenreId = 2 }

);


        }
    }
}
