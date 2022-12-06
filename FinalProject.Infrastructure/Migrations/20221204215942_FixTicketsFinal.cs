using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class FixTicketsFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "TicketReference",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68b847a1-1005-4077-9d67-8f102ed78f4d", "AQAAAAEAACcQAAAAEPbYfnBNLEEU4fNkrUetMpbF5Yi7qn0uS+aSRfX++PYSQxeZIrmUxGG29NrrAwT/FA==", "d0bb0db9-b32d-4dfe-a54a-b2e48b242fe5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25c0dda6-520e-4ca8-a4bf-9aac1b426e78", "AQAAAAEAACcQAAAAEHM+XOUAMUmq/+77h15aVfQjYOIdWyGwiQjF9G2X3wOfwehcWwnMyzZ53h8kJJWJcA==", "87efd27e-3823-4a6a-ac55-a937055a12dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9266d6cf-a8b4-4b69-a8c4-0f696aa6f0f9", "AQAAAAEAACcQAAAAEMD1lOy/6JD5MCUP+2O8CkzeaT/5kCt/sd0ukaGspOOwK8EeyM3T1zGPbac9KPAETg==", "9b7a502b-7df8-4e1b-b4be-669e4da6d9b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "517ec4aa-7852-4e38-9e1e-845a66f250dc", "AQAAAAEAACcQAAAAEJGOo7c3DZ1xEqCyA4oLb6Yk/UuN1k2BAzbgvuEb+fXUgNNl5G1HQeZ/2LprLMpGJA==", "a0463970-23fc-4e13-a08c-f2a0669c27c8" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Likes", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("011f7407-8c0e-4025-a42f-677b2c44406c"), 3, new DateTime(2022, 12, 4, 23, 59, 42, 369, DateTimeKind.Local).AddTicks(1977), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") },
                    { new Guid("65a29964-3ccc-49ef-85c7-cf772c3459c5"), 4, new DateTime(2022, 12, 4, 23, 59, 42, 369, DateTimeKind.Local).AddTicks(1983), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") },
                    { new Guid("e21ba7b7-1cd3-4754-8182-20b0a5768a05"), 2, new DateTime(2022, 12, 4, 23, 59, 42, 369, DateTimeKind.Local).AddTicks(1971), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("e5d8464b-a40e-4f93-8dcd-f6c914a552dd"), 1, new DateTime(2022, 12, 4, 23, 59, 42, 369, DateTimeKind.Local).AddTicks(1908), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("011f7407-8c0e-4025-a42f-677b2c44406c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("65a29964-3ccc-49ef-85c7-cf772c3459c5"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e21ba7b7-1cd3-4754-8182-20b0a5768a05"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e5d8464b-a40e-4f93-8dcd-f6c914a552dd"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TicketReference",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
