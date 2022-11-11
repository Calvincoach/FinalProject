using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca", 0, "e09c14be-1036-4d6a-afd3-7e29c9efffac", "guest3@gmail.com", false, false, null, "guest3@gmail.com", "guest3", "AQAAAAEAACcQAAAAECmqvUP10htuGRpJV/f4E4mzTCjWpU2MjLo01yu8B+Bh2QO9ErCehBY4pQmmr+ZVjQ==", null, false, "505793c9-ef2a-4124-994a-699b98ca6a19", false, "guest3" },
                    { "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c", 0, "e4038bce-b830-4d21-ba4e-4442541236b2", "guest1@gmail.com", false, false, null, "guest1@gmail.com", "guest1", "AQAAAAEAACcQAAAAENayYFvnsmlx26waZsLmAkJPH9tgZpYUpX6/emQC8fFujwBgiq2mpuOju7E8/0So4w==", null, false, "5f8b9a77-e9c8-4d30-84ed-116c15e0af53", false, "guest1" },
                    { "d58dadb8-e031-41e7-875e-da7378709cb5", 0, "ebe2735c-fb69-4408-8a74-ef0b5a2096d4", "admin1@gmail.com", false, false, null, "admin1@gmail.com", "admin1", "AQAAAAEAACcQAAAAEDup4CYvMXeJPrWdM1VhJn5meTFwjhVvCOrs7B0rwkPVFCobMk3SsmOjXDjM6CuZtQ==", null, false, "2f5620c3-c4b8-4dd0-800b-6c350c4bc5b1", false, "admin1" },
                    { "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374", 0, "e3e76fbf-fc24-48d5-9e12-b10528d41ec2", "guest2@gmail.com", false, false, null, "guest2@gmail.com", "guest2", "AQAAAAEAACcQAAAAEG1IYnse7aqN2Lvi7xXapIKluWlsmIQDYyHwnY+U5tsAP8BPQkoPWp7SruGcMpXZ8A==", null, false, "5638030c-0a87-44c2-9d59-6e5dc01067a5", false, "guest2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Music" },
                    { 2, "Theatre" },
                    { 3, "Movie" },
                    { 4, "Charity" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "City", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96"), 5000, "Burgas", "", "Culture Home Burgas" },
                    { new Guid("4611cec5-9233-4c0c-9201-529b9af6235d"), 500, "Sofia", "", "Sofia Puppet Theatre" },
                    { new Guid("b80248ba-4607-498e-bbd5-afd4f7221979"), 1500, "Plovdiv", "", "CinemaCity" },
                    { new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719"), 200, "Varna", "", "Hale3" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Likes", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("05a0ff55-332f-4048-9378-0e4c9b614e2b"), 2, new DateTime(2022, 11, 11, 23, 1, 38, 156, DateTimeKind.Local).AddTicks(1257), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("093a12b3-2021-45a2-8f3c-304ef44aa2db"), 4, new DateTime(2022, 11, 11, 23, 1, 38, 156, DateTimeKind.Local).AddTicks(1275), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") },
                    { new Guid("184862cb-2647-4945-9556-43ea99436df2"), 3, new DateTime(2022, 11, 11, 23, 1, 38, 156, DateTimeKind.Local).AddTicks(1264), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") },
                    { new Guid("f2dd87ce-43ac-46d6-a01e-6c1e11c14a51"), 1, new DateTime(2022, 11, 11, 23, 1, 38, 156, DateTimeKind.Local).AddTicks(1206), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("05a0ff55-332f-4048-9378-0e4c9b614e2b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("093a12b3-2021-45a2-8f3c-304ef44aa2db"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("184862cb-2647-4945-9556-43ea99436df2"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f2dd87ce-43ac-46d6-a01e-6c1e11c14a51"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("4611cec5-9233-4c0c-9201-529b9af6235d"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("b80248ba-4607-498e-bbd5-afd4f7221979"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719"));

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Venues");
        }
    }
}
