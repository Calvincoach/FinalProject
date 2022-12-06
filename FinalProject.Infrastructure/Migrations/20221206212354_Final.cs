using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("2312dc49-a8e5-4a4c-b939-4bebe6268acb"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("2332a08f-326d-47a6-8bc4-58fed5cc4385"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ade3d297-79d4-425c-9951-97f62b520d99"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b7bf277e-20a2-40e4-bd46-f1b1a938e255"));

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0375c08-01c0-4d52-b53e-5e575f6c6b00", "AQAAAAEAACcQAAAAEI8Qi4+xuJLcIc78I9kGitH8V1Oxjjm/g9v1w/E5WatHeo/pB1NYQNWCZZz2Lzkr9Q==", "d6768b4c-292c-4780-a7a3-f4b5ee4feb1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "946ac1f3-c84a-4b8b-899f-592077dc6287", "AQAAAAEAACcQAAAAEBNYGYwm1PkkB8346wfGbgk4bfyQBfQEfA5QjQqjWdMwidPA0ZBwY/ZhfcuPCOWcwg==", "3e7754f5-0a8c-4c5d-af0a-2896843c12f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "accb6b2c-9370-4ed6-9a68-1219d9f7bafb", "AQAAAAEAACcQAAAAEJx7m+2ia5xw8/BX4SFv+7taZwD4jWdnwkWQlaZtR1/nsYzrSCbMpGpuHC2fMomQDA==", "6a98c412-a5a0-48c4-b503-0c68ef4b9b09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ced6f9af-a618-491c-837a-27e00d0f6d81", "AQAAAAEAACcQAAAAEPZ9OU4MwMG8gOWguy86LN4qiVYrOkbse2Bh+tMgiv9R7BNzKHYdibWbbD8mHTXqjA==", "83deee61-cfc0-4bd1-9842-b9a12360b8ae" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("3c5c7e27-e706-4476-b139-8639c51e891f"), 1, new DateTime(2022, 12, 6, 23, 23, 53, 774, DateTimeKind.Local).AddTicks(111), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") },
                    { new Guid("79d17e7d-a085-4fe2-abde-0f68661be362"), 3, new DateTime(2022, 12, 6, 23, 23, 53, 774, DateTimeKind.Local).AddTicks(172), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") },
                    { new Guid("b9433dcc-175a-447c-ba1d-4c99bdb36232"), 2, new DateTime(2022, 12, 6, 23, 23, 53, 774, DateTimeKind.Local).AddTicks(159), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("eeb72a3e-2bc8-4e45-8199-177831d10175"), 4, new DateTime(2022, 12, 6, 23, 23, 53, 774, DateTimeKind.Local).AddTicks(241), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3c5c7e27-e706-4476-b139-8639c51e891f"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("79d17e7d-a085-4fe2-abde-0f68661be362"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b9433dcc-175a-447c-ba1d-4c99bdb36232"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("eeb72a3e-2bc8-4e45-8199-177831d10175"));

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6764337f-31de-4fe6-8195-536a91b48729", "AQAAAAEAACcQAAAAEInAXsePaXCAJU+LamdQZ6ItjpnZOj6iIPE1W5WOvlN0uziHqqIOaxGO8uc6uhk2Mw==", "f2b06660-779c-48ab-a2f9-ad93f283c281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfe7df97-3660-4e17-b16b-a68bed194eaf", "AQAAAAEAACcQAAAAEAQKbw4ZEgzEq4m5AbEUREj9e6sOz3Iq4SG7WwnFFqvzqHMUGUC36t3gD9PYgWlDWg==", "55608d60-0b44-4d5d-9905-2f7a212b1be8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4a1fd3b-f120-4da2-baf6-56978d791f5f", "AQAAAAEAACcQAAAAEEBOXYqSyQ3+98G5OWELxNa+gmS+inCFkFfTT7IEp+FaYO78yjnTngzFRGcu8+htrQ==", "9c0b5766-7459-4328-97af-e95559a61ccf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "943c29a9-8b78-4433-aa99-51c15337653c", "AQAAAAEAACcQAAAAENsebNUyyGRGb8xgJCxjN5id35LjKiFueSv+nQboFMyNooAN6wCwv4eNd9j/oCO2rg==", "15250bda-2423-4ef0-9517-57b214ff7fd7" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Likes", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("2312dc49-a8e5-4a4c-b939-4bebe6268acb"), 4, new DateTime(2022, 12, 6, 22, 15, 2, 236, DateTimeKind.Local).AddTicks(6230), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") },
                    { new Guid("2332a08f-326d-47a6-8bc4-58fed5cc4385"), 1, new DateTime(2022, 12, 6, 22, 15, 2, 236, DateTimeKind.Local).AddTicks(6174), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") },
                    { new Guid("ade3d297-79d4-425c-9951-97f62b520d99"), 2, new DateTime(2022, 12, 6, 22, 15, 2, 236, DateTimeKind.Local).AddTicks(6218), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("b7bf277e-20a2-40e4-bd46-f1b1a938e255"), 3, new DateTime(2022, 12, 6, 22, 15, 2, 236, DateTimeKind.Local).AddTicks(6224), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") }
                });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96"),
                column: "Capacity",
                value: 5000);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("4611cec5-9233-4c0c-9201-529b9af6235d"),
                column: "Capacity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("b80248ba-4607-498e-bbd5-afd4f7221979"),
                column: "Capacity",
                value: 1500);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719"),
                column: "Capacity",
                value: 200);
        }
    }
}
