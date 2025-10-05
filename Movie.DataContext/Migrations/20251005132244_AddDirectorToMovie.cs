using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectorToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritess_Movies_MovieId",
                table: "Favoritess");

            migrationBuilder.DropForeignKey(
                name: "FK_Favoritess_Userss_UserId",
                table: "Favoritess");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Userss_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ViewHistory_Userss_UserId",
                table: "ViewHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userss",
                table: "Userss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritess",
                table: "Favoritess");

            migrationBuilder.RenameTable(
                name: "Userss",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Favoritess",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Userss_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Favoritess_UserId",
                table: "Favorites",
                newName: "IX_Favorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favoritess_MovieId",
                table: "Favorites",
                newName: "IX_Favorites_MovieId");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Movies_MovieId",
                table: "Favorites",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViewHistory_Users_UserId",
                table: "ViewHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Movies_MovieId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ViewHistory_Users_UserId",
                table: "ViewHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Userss");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favoritess");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Userss",
                newName: "IX_Userss_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UserId",
                table: "Favoritess",
                newName: "IX_Favoritess_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_MovieId",
                table: "Favoritess",
                newName: "IX_Favoritess_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userss",
                table: "Userss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritess",
                table: "Favoritess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritess_Movies_MovieId",
                table: "Favoritess",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritess_Userss_UserId",
                table: "Favoritess",
                column: "UserId",
                principalTable: "Userss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Userss_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Userss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViewHistory_Userss_UserId",
                table: "ViewHistory",
                column: "UserId",
                principalTable: "Userss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
