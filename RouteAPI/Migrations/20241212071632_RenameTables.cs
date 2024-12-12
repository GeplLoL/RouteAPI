using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Buses_BusId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "MyRoutes");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_BusId",
                table: "MyRoutes",
                newName: "IX_MyRoutes_BusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyRoutes",
                table: "MyRoutes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyRoutes_Buses_BusId",
                table: "MyRoutes",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyRoutes_Buses_BusId",
                table: "MyRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyRoutes",
                table: "MyRoutes");

            migrationBuilder.RenameTable(
                name: "MyRoutes",
                newName: "Routes");

            migrationBuilder.RenameIndex(
                name: "IX_MyRoutes_BusId",
                table: "Routes",
                newName: "IX_Routes_BusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Buses_BusId",
                table: "Routes",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
