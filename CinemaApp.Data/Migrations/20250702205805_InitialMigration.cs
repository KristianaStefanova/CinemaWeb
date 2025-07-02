using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Cinema identifier"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Cinema name"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Cinema location"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if cinema is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                },
                comment: "Cinema in the system");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Movie identifier"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie title"),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Movie genre"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Movie release date"),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie director"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Movie duration"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Movie description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Movie image url from the image store"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                },
                comment: "Movie in the system");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserMovies",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key to the referenced AspNetUser. Part of the entity composite PK."),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced Movie. Part of the entity composite PK."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if ApplicationUserMovie entry is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMovies", x => new { x.ApplicationUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User Watchlist entry in the system.");

            migrationBuilder.CreateTable(
                name: "CinemasMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Movie projection identifier"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the movie"),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the cinema"),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Count of currently available tickets"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if the movie projection in a cinema is active"),
                    Showtime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "String indicating the showtime of the Movie projection")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemasMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Movie projection in a cinema in the system");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Ticket identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Ticket price"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Tickets quantity bought"),
                    CinemaMovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the Movie projection in a Cinema"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key to the owner of the ticket")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_CinemasMovies_CinemaMovieId",
                        column: x => x.CinemaMovieId,
                        principalTable: "CinemasMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Ticket in the system");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ImageUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("25163666-81d7-4829-9931-b6bd44eb2b23"), "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much more.", "David Fincher", 139, "Drama", "https://www.movieposters.com/cdn/shop/files/FightClub.mpw.125100_480x.progressive.jpg?v=1707497058", new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", "Christopher Nolan", 169, "Adventure", "https://www.movieposters.com/cdn/shop/files/interstellar-139399_480x.progressive.jpg?v=1708527823", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { new Guid("3fcdb107-dc27-45a0-8514-e2b40714100e"), "A young FBI trainee seeks the help of an imprisoned cannibalistic serial killer to catch another serial killer.", "Jonathan Demme", 118, "Thriller", "https://www.movieposters.com/cdn/shop/files/silencelambs.C.17449.mpw_480x.progressive.jpg?v=1727097024", new DateTime(1991, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silence of the Lambs" },
                    { new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), "A skilled thief is given a chance at redemption if he can successfully perform an inception on a target's mind.", "Christopher Nolan", 148, "Sci-Fi", "https://cdn.shopify.com/s/files/1/0057/3728/3618/files/inception.mpw.123395_9e0000d1-bc7f-400a-b488-15fa9e60a10c_500x749.jpg?v=1708527589", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { new Guid("4b760743-8d49-48d5-bca6-15f5236e3f7b"), "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.", "Ridley Scott", 155, "Action", "https://www.movieposters.com/cdn/shop/files/Gladiator.mpw.102813_480x.progressive.jpg?v=1707500493", new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator" },
                    { new Guid("75fb6394-ab90-4b78-9802-7ff3c9afdbc0"), "A businessman saves the lives of hundreds of Jews during the Holocaust by employing them in his factories.", "Steven Spielberg", 195, "Drama", "https://www.movieposters.com/cdn/shop/products/9a1f9ea4a27071481cc1263e3ea11f7b_7bdb2deb-dd50-41b5-beab-8fc1cb3c895d_480x.progressive.jpg?v=1573651233", new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List" },
                    { new Guid("7dd82b97-1eb2-4c37-9c3d-e26dd84878a0"), "The lives of guards on Death Row are affected by one of their charges, a black man accused of child murder and rape, yet who has a mysterious gift.", "Frank Darabont", 189, "Drama", "https://www.movieposters.com/cdn/shop/products/033152cb8ba4518411a359686f4a194e_e51d49fa-d8b2-4aaf-82dd-9779f297352c_480x.progressive.jpg?v=1573585373", new DateTime(1999, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Green Mile" },
                    { new Guid("8c5904a9-bfab-4b0f-b12b-b5fc795e6231"), "The story of Forrest Gump, a man with a low IQ, whose kind heart shapes the lives of those around him.", "Robert Zemeckis", 142, "Drama", "https://www.movieposters.com/cdn/shop/products/forrest-gump---24x36_480x.progressive.jpg?v=1645558337", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("94e73f37-e260-4c6f-930b-8bd65c9c8a11"), "The lives of two mob hitmen, a boxer, and others intertwine in a series of unexpected incidents.", "Quentin Tarantino", 154, "Crime", "https://www.movieposters.com/cdn/shop/products/pulpfiction.2436_480x.progressive.jpg?v=1620048742", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"), "A computer hacker learns the shocking truth about the reality he lives in and joins a rebellion.", "The Wachowskis", 136, "Sci-Fi", "https://www.movieposters.com/cdn/shop/files/Matrix.mpw.102176_bb2f6cc5-4a16-4512-881b-f855ead3c8ec_480x.progressive.jpg?v=1708703624", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("9912f515-b2aa-4d19-9d2f-c2c94cb1212e"), "Earth's mightiest heroes must come together to stop a mischievous Loki and his alien army.", "Joss Whedon", 143, "Action", "https://www.movieposters.com/cdn/shop/files/avengers.24x36_480x.progressive.jpg?v=1707410714", new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers" },
                    { new Guid("b0c21023-aa37-49cb-ad91-3ba005d8550d"), "With the help of a German bounty hunter, a freed slave sets out to rescue his wife from a brutal Mississippi plantation owner.", "Quentin Tarantino", 165, "Western", "https://www.movieposters.com/cdn/shop/products/ff35c38cb67f47a5f4cbec6c92a5d5a8_acb37f4c-8110-4bc9-b597-01e75e565a60_480x.progressive.jpg?v=1573587558", new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Django Unchained" },
                    { new Guid("bec8f441-5b73-4f11-87b8-a47fbc1d140f"), "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", "Steven Spielberg", 127, "Adventure", "https://www.movieposters.com/cdn/shop/files/jurassicpark.mpw_480x.progressive.jpg?v=1713805481", new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { new Guid("c994999b-02dd-46c2-abc4-00c4787e629f"), "A paraplegic Marine dispatched to the moon Pandora becomes torn between following orders and protecting his home.", "James Cameron", 162, "Sci-Fi", "https://www.movieposters.com/cdn/shop/files/avatar.adv.24x36_480x.progressive.jpg?v=1707410703", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar" },
                    { new Guid("e0d85412-0717-4648-a972-f393a6aafaa8"), "A lion prince flees his kingdom after the death of his father, only to learn the true meaning of responsibility and bravery.", "Roger Allers, Rob Minkoff", 88, "Animation", "https://www.movieposters.com/cdn/shop/files/the-lion-king_273b54a5_480x.progressive.jpg?v=1725905168", new DateTime(1994, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King" },
                    { new Guid("e673a37c-8ffc-46bf-a66d-18b8078d7c94"), "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", "Francis Ford Coppola", 175, "Crime", "https://www.movieposters.com/cdn/shop/products/b5282f72126e4919911509e034a61f66_6ce2486d-e0da-4b7a-9148-722cdde610b8_480x.progressive.jpg?v=1573616025", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), "Batman faces the Joker, a criminal mastermind bent on causing chaos in Gotham City.", "Christopher Nolan", 152, "Action", "https://www.movieposters.com/cdn/shop/files/darkknight.building.24x36_20e90057-f673-4cc3-9ce7-7b0d3eeb7d83_480x.progressive.jpg?v=1707491191", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("f1342f7d-ff72-4bfb-8a36-8368dec7b088"), "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of decency.", "Frank Darabont", 142, "Drama", "https://www.movieposters.com/cdn/shop/files/shawshank_eb84716b-efa9-44dc-a19d-c17924a3f7df_480x.progressive.jpg?v=1709821984", new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMovies_MovieId",
                table: "ApplicationUserMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_Name_Location",
                table: "Cinemas",
                columns: new[] { "Name", "Location" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CinemasMovies_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemasMovies_MovieId_CinemaId_Showtime",
                table: "CinemasMovies",
                columns: new[] { "MovieId", "CinemaId", "Showtime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaMovieId_UserId",
                table: "Tickets",
                columns: new[] { "CinemaMovieId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserMovies");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CinemasMovies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
