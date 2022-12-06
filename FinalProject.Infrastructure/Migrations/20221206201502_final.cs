using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTicket");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1dcfdd10-337e-4b13-b2b6-5bc812cc60ae"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3aae4e77-fbac-458f-b8eb-d9ae8d9b94a6"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("6b655724-c0e8-4606-8cf8-a0a41879d038"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d945e549-927c-475d-af4f-70e88b6e3994"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EventId",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "EventTicket",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicket", x => new { x.EventId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_EventTicket_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicket_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acd28ffc-fc5a-4026-89f8-467b386e5fb6", "AQAAAAEAACcQAAAAEG5NzJN6fea3RLEArA1bMOJfHOurMK8cPAf4S6tDCiv/jOs6caMWGVg3m9G9FHeKMQ==", "0117e0fa-ff4f-47fc-91d6-8aad60f17ef0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a175650b-81e4-4bc1-a9dc-f424d003ba61", "AQAAAAEAACcQAAAAEFfxkB5Siqy9BVqeYhKJVad/jCs1kTca8rc3Z57dSj4BZ03Cbzze7P35g2SCZs3RaA==", "b8b563c3-474c-4a34-b09a-e492d102f04a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d58dadb8-e031-41e7-875e-da7378709cb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3a91885-a437-4a6c-8990-3d7027a458fe", "AQAAAAEAACcQAAAAELeHzYjJ1NfL/Pg9zmxG+7gYI0U94xk9vjmriH+Tz4m28bmXdg4hBlGYumq0xaMluw==", "a264c54b-df43-469e-8daf-de287750434a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "667d5a5e-d416-4ded-a629-6814832bac7b", "AQAAAAEAACcQAAAAEM0DDBo1Fkq4RXa+5KrObH+p0r0hPM4pTMOd3PFJ6lp7WYtXt+paKtISnk5SHlDGxg==", "84ec14d8-fd73-4732-adc6-625b3662beef" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "EventOrganiser", "ImageUrl", "Interested", "Likes", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { new Guid("1dcfdd10-337e-4b13-b2b6-5bc812cc60ae"), 1, new DateTime(2022, 12, 6, 21, 57, 34, 992, DateTimeKind.Local).AddTicks(9209), "Sunami EP promo live, be there. ", "REAL BAY SH*T", "https://f4.bcbits.com/img/a0705911045_10.jpg", 0, 0, "Sunami Live Concert", 20m, new Guid("b83b35c8-1c9d-4404-a7c9-a76cc9617719") },
                    { new Guid("3aae4e77-fbac-458f-b8eb-d9ae8d9b94a6"), 2, new DateTime(2022, 12, 6, 21, 57, 34, 992, DateTimeKind.Local).AddTicks(9320), "The puppets show is in town, bring your kids for a fun spectacle.", "Sofia Theatre", "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg", 0, 0, "The frog king", 10m, new Guid("4611cec5-9233-4c0c-9201-529b9af6235d") },
                    { new Guid("6b655724-c0e8-4606-8cf8-a0a41879d038"), 3, new DateTime(2022, 12, 6, 21, 57, 34, 992, DateTimeKind.Local).AddTicks(9328), "The premiere of the new Batman coming to this fall.", "Matt Reeves", "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg", 0, 0, "The Batman (2022) Premiere", 12m, new Guid("b80248ba-4607-498e-bbd5-afd4f7221979") },
                    { new Guid("d945e549-927c-475d-af4f-70e88b6e3994"), 4, new DateTime(2022, 12, 6, 21, 57, 34, 992, DateTimeKind.Local).AddTicks(9334), "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.", "JPMorgan", "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter", 0, 0, "Charity", 0m, new Guid("197ee165-a4da-46d7-893a-f1cefc6ddc96") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTicket_TicketId",
                table: "EventTicket",
                column: "TicketId");
        }
    }
}
