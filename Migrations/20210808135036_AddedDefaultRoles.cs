using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsApi.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8656762d-b0bc-4e23-b737-c1e85ea7ccc1", "754da09b-c54b-4d1e-a5c4-7af946de13bb", "User", "USER" },
                    { "2d951586-e780-421b-8dce-0e2f0b368e73", "c93baf2a-feed-49e8-a1ea-ed6caea62c42", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d951586-e780-421b-8dce-0e2f0b368e73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8656762d-b0bc-4e23-b737-c1e85ea7ccc1");
        }
    }
}
