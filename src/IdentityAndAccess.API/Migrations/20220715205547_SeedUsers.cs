using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityAndAccess.API.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96217ec2-f2da-4fc9-9df5-42c2d4a7796f", "4f63d654-5fa1-4527-a48d-09c168c247e4", "User", "USER" },
                    { "c72244d8-eb42-11ec-8fea-0242ac120002", "d92e296b-c0b3-4d41-b1ec-e9ba56a1a632", "Admin", "ADMIN" },
                    { "fa1a7297-8b66-4e97-9a8d-073329a96f8a", "73a89c5b-bf24-4f51-b1f2-f9c06738d7fe", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bf3f3f96-eb42-11ec-8fea-0242ac120002", 0, "2deb9f4c-ee28-4a14-b4d2-4c0a1649660d", "admin@test.com", true, true, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEIUYucqtBIHroQE0TlozPX8XiRuh0wICDGvFMUiQFm6jbFI34XgluTuDBJHhA1Bb+g==", null, false, "a48e7992-eb46-11ec-8ea0-0242ac120002", false, "admin@test.com" },
                    { "c4521861-05a3-4489-9eb1-dac03a60f1bb", 0, "00c91cc9-8be5-4020-a46e-f892214ba570", "user@test.com", true, true, null, "USER@TEST.COM", "USER@TEST.COM", "AQAAAAEAACcQAAAAEHzKNpjG/ZnM9V8//ls1gMl0eajbdJMdkJSdUCsJzstDc5Fsuu52Y6W4vCMxHb6H3w==", null, false, "270409d9-bb0c-4bdf-8f47-a302dc395a0c", false, "user@test.com" },
                    { "f5e4f537-9d10-4338-a063-a9ebe8a8b446", 0, "016ae5b8-3f23-49e3-b815-4fcacfff7bbe", "manager@test.com", true, true, null, "MANAGER@TEST.COM", "MANAGER@TEST.COM", "AQAAAAEAACcQAAAAEMzVMwnRQeRs5Xdqyj5eeezJ/pXuqSOOiMqqoNubAvBNn0iKnWQZ4lTv7qXlsr13bA==", null, false, "22545daa-46e8-4033-8ae9-379871bd59e8", false, "manager@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Permission", "CanRead, CanCreate, CanUpdate, CanDelete", "bf3f3f96-eb42-11ec-8fea-0242ac120002" },
                    { 2, "Permission", "CanRead, CanCreate, CanUpdate", "f5e4f537-9d10-4338-a063-a9ebe8a8b446" },
                    { 3, "Permission", "CanRead", "c4521861-05a3-4489-9eb1-dac03a60f1bb" },
                    { 4, "CanDelete", "CanDelete", "bf3f3f96-eb42-11ec-8fea-0242ac120002" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c72244d8-eb42-11ec-8fea-0242ac120002", "bf3f3f96-eb42-11ec-8fea-0242ac120002" },
                    { "96217ec2-f2da-4fc9-9df5-42c2d4a7796f", "c4521861-05a3-4489-9eb1-dac03a60f1bb" },
                    { "fa1a7297-8b66-4e97-9a8d-073329a96f8a", "f5e4f537-9d10-4338-a063-a9ebe8a8b446" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c72244d8-eb42-11ec-8fea-0242ac120002", "bf3f3f96-eb42-11ec-8fea-0242ac120002" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "96217ec2-f2da-4fc9-9df5-42c2d4a7796f", "c4521861-05a3-4489-9eb1-dac03a60f1bb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa1a7297-8b66-4e97-9a8d-073329a96f8a", "f5e4f537-9d10-4338-a063-a9ebe8a8b446" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96217ec2-f2da-4fc9-9df5-42c2d4a7796f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c72244d8-eb42-11ec-8fea-0242ac120002");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa1a7297-8b66-4e97-9a8d-073329a96f8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf3f3f96-eb42-11ec-8fea-0242ac120002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4521861-05a3-4489-9eb1-dac03a60f1bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5e4f537-9d10-4338-a063-a9ebe8a8b446");
        }
    }
}
