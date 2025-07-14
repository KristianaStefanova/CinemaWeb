using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCinemaMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CinemasMovies",
                columns: new[] { "Id", "AvailableTickets", "CinemaId", "MovieId", "Showtime" },
                values: new object[,]
                {
                    { new Guid("0241c54a-37e7-4c9a-bcfb-43f0a60749e2"), 60, new Guid("5ae6c761-1363-4a23-9965-171c70f935de"), new Guid("8c5904a9-bfab-4b0f-b12b-b5fc795e6231"), "17:00" },
                    { new Guid("0e5c76b7-9e27-4217-a113-5cafd558d00f"), 70, new Guid("f4c3e429-0e36-47af-99a2-0c7581a7fc67"), new Guid("7dd82b97-1eb2-4c37-9c3d-e26dd84878a0"), "18:15" },
                    { new Guid("130f6630-5593-4165-8e9e-de718ee1fb72"), 70, new Guid("5ae6c761-1363-4a23-9965-171c70f935de"), new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), "20:15" },
                    { new Guid("30864830-db09-412a-a816-6dbaccc1374c"), 150, new Guid("be80d2e4-1c91-4e86-9b73-12ef08c9c3d2"), new Guid("c994999b-02dd-46c2-abc4-00c4787e629f"), "17:45" },
                    { new Guid("30c505d0-9833-4087-9377-43ac8ab34e07"), 90, new Guid("f4c3e429-0e36-47af-99a2-0c7581a7fc67"), new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), "21:00" },
                    { new Guid("3291c19e-5995-48af-9124-35f855bf8476"), 95, new Guid("8a1fdfb4-08c9-44a2-a46e-0b3c45ff57b9"), new Guid("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), "19:45" },
                    { new Guid("6a7071a9-0c3d-42e5-9514-639c5fb259a3"), 100, new Guid("33c36253-9b68-4d8a-89ae-f3276f1c3f8a"), new Guid("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"), "16:00" },
                    { new Guid("71a411ec-d23c-4abb-b50c-75571d0a3cff"), 120, new Guid("8a1fdfb4-08c9-44a2-a46e-0b3c45ff57b9"), new Guid("b0c21023-aa37-49cb-ad91-3ba005d8550d"), "18:30" },
                    { new Guid("93f61e0c-6e62-41bb-b4e2-fc770ac48128"), 40, new Guid("5ae6c761-1363-4a23-9965-171c70f935de"), new Guid("94e73f37-e260-4c6f-930b-8bd65c9c8a11"), "22:30" },
                    { new Guid("9d54f01b-b33d-4ed5-8c4c-6874d62b24dd"), 110, new Guid("be80d2e4-1c91-4e86-9b73-12ef08c9c3d2"), new Guid("f1342f7d-ff72-4bfb-8a36-8368dec7b088"), "20:00" },
                    { new Guid("a22c43b7-bd1d-46cd-b419-dba244e533cc"), 85, new Guid("f4c3e429-0e36-47af-99a2-0c7581a7fc67"), new Guid("f1342f7d-ff72-4bfb-8a36-8368dec7b088"), "20:00" },
                    { new Guid("c96549ed-7a19-4e83-856e-976cf306d611"), 60, new Guid("33c36253-9b68-4d8a-89ae-f3276f1c3f8a"), new Guid("4b760743-8d49-48d5-bca6-15f5236e3f7b"), "19:00" },
                    { new Guid("d00af316-049a-4bd5-97c2-c55fcab99783"), 80, new Guid("be80d2e4-1c91-4e86-9b73-12ef08c9c3d2"), new Guid("3fcdb107-dc27-45a0-8514-e2b40714100e"), "20:30" },
                    { new Guid("ef18d96e-2e5b-4218-b552-e094e98ac178"), 50, new Guid("8a1fdfb4-08c9-44a2-a46e-0b3c45ff57b9"), new Guid("94e73f37-e260-4c6f-930b-8bd65c9c8a11"), "22:00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("0241c54a-37e7-4c9a-bcfb-43f0a60749e2"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("0e5c76b7-9e27-4217-a113-5cafd558d00f"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("130f6630-5593-4165-8e9e-de718ee1fb72"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("30864830-db09-412a-a816-6dbaccc1374c"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("30c505d0-9833-4087-9377-43ac8ab34e07"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("3291c19e-5995-48af-9124-35f855bf8476"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("6a7071a9-0c3d-42e5-9514-639c5fb259a3"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("71a411ec-d23c-4abb-b50c-75571d0a3cff"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("93f61e0c-6e62-41bb-b4e2-fc770ac48128"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("9d54f01b-b33d-4ed5-8c4c-6874d62b24dd"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("a22c43b7-bd1d-46cd-b419-dba244e533cc"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("c96549ed-7a19-4e83-856e-976cf306d611"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("d00af316-049a-4bd5-97c2-c55fcab99783"));

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumn: "Id",
                keyValue: new Guid("ef18d96e-2e5b-4218-b552-e094e98ac178"));
        }
    }
}
