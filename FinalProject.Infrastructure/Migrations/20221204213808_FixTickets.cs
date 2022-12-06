using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class FixTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("500c92e0-4910-4ad1-a0f8-42abe7168adc"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("86daddbb-db78-4535-a1db-e2c41b504161"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("a56797ac-08ad-441d-af7b-b12881ee5b18"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("edf1c1cc-7fc6-46e4-ab75-c1498dbf7f59"));

            migrationBuilder.AddColumn<string>(
                name: "TicketHolder",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketReference",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55fa86f8-18d2-4a0c-8437-61d726208e21", "AQAAAAEAACcQAAAAEPERUdUrklsVz5TMusswFNjkt5/LQk2hHFg34/oYxt85XJ1KXgaTgrqDCWB2QTuzhA==", "9d01324b-79da-47c0-aedb-4b928b2bb63e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "850c4e2d-4649-4cd6-af06-0179cc1d7b57", "AQAAAAEAACcQAAAAEI0iXEWhdzwMedrV5kvIbZ8LlTkPh/ge9B4vzwGfgvM6doj1KQbV+fb/6MQimUbBcw==", "2213cca7-aaff-493e-a291-dbd86eb77d58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b601820-76a5-4eb4-9c67-39437bd93003", "AQAAAAEAACcQAAAAELgLLIi2YRpif8IUBLYNm77UcTbBKMnPLmiId2P//hcH+gRc/CBcCfn5ObzoBhxqKg==", "2084cfa1-53aa-4eb2-bbf3-0efddec1ffa7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bff1460-25fb-4966-b522-604f7bbd480b", "AQAAAAEAACcQAAAAEN2X74D62n6Ov7FCANE/JdTo5KsOs5txiwQsd9gDrApJ+yY5LgqLgEJb/iJY9zfTcA==", "596c6ce6-da98-4cea-99dc-b5931994b448" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Likes", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("51a6bfde-1347-4671-bdb2-efd0773e413b"), 4, new DateTime(2022, 12, 4, 23, 38, 7, 757, DateTimeKind.Local).AddTicks(3861), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") },
                    { new Guid("5f515b64-ea81-41dd-ade2-9eadf31442b4"), 2, new DateTime(2022, 12, 4, 23, 38, 7, 757, DateTimeKind.Local).AddTicks(3729), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("f4673e73-a421-48b5-a2c4-518b75c2f0b0"), 3, new DateTime(2022, 12, 4, 23, 38, 7, 757, DateTimeKind.Local).AddTicks(3735), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") },
                    { new Guid("fc1565c9-c66b-4355-8a8c-7fd242f08ffc"), 1, new DateTime(2022, 12, 4, 23, 38, 7, 757, DateTimeKind.Local).AddTicks(3672), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("51a6bfde-1347-4671-bdb2-efd0773e413b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5f515b64-ea81-41dd-ade2-9eadf31442b4"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f4673e73-a421-48b5-a2c4-518b75c2f0b0"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fc1565c9-c66b-4355-8a8c-7fd242f08ffc"));

            migrationBuilder.DropColumn(
                name: "TicketHolder",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketReference",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38af127b-8da6-43d4-955c-91689c55be6d", "AQAAAAEAACcQAAAAEDFZXF/KFNLxoHUdVM0K4LaHwXOrV1rni68092GxA7MqobinRtVMJQu5flH8PVxqCA==", "cf8e79df-8a34-4ebb-aa10-82bd25bd31e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86816d81-3c04-401a-9250-29f5efe292f5", "AQAAAAEAACcQAAAAEFmbmtJbEVVJls42YEIli+m8GMX+bIz11ygx2QITkAl07dp9gt5UGB7X6Ly0lT30Yw==", "e892746f-7e3e-4e6b-93ad-f3608b22a72f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59710ab7-e448-41a4-b5da-bba744a884b4", "AQAAAAEAACcQAAAAEOhA1DCuR1OnDTXUchj2aETm17998fzHe34Ga9jcMOt6mWrFbDfYRverC4Y2AOiMuQ==", "c10efa23-f0ef-43bf-978a-d604914e7d55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eef8efd-1120-4509-baad-bd7adba82b32", "AQAAAAEAACcQAAAAEKXNWFQI1XHXYjEuAJwjD+fhkB9zBLgOf1ajLbrl2R55YVtrbuuLuEgtS+TIVmocDA==", "2f9cf94e-d0a0-4f0d-99cd-9d76f04f0ffb" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Likes", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("500c92e0-4910-4ad1-a0f8-42abe7168adc"), 4, new DateTime(2022, 11, 12, 23, 10, 11, 539, DateTimeKind.Local).AddTicks(329), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") },
                    { new Guid("86daddbb-db78-4535-a1db-e2c41b504161"), 2, new DateTime(2022, 11, 12, 23, 10, 11, 539, DateTimeKind.Local).AddTicks(318), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("a56797ac-08ad-441d-af7b-b12881ee5b18"), 3, new DateTime(2022, 11, 12, 23, 10, 11, 539, DateTimeKind.Local).AddTicks(324), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") },
                    { new Guid("edf1c1cc-7fc6-46e4-ab75-c1498dbf7f59"), 1, new DateTime(2022, 11, 12, 23, 10, 11, 539, DateTimeKind.Local).AddTicks(267), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") }
                });
        }
    }
}
