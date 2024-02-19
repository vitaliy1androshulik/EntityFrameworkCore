using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnitityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Passangers_ClientsId",
                table: "ClientFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passangers",
                table: "Passangers");

            migrationBuilder.RenameTable(
                name: "Passangers",
                newName: "Passengers");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureSity",
                table: "Flights",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Airplanes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsId",
                table: "ClientFlight",
                column: "ClientsId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsId",
                table: "ClientFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Passangers");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureSity",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Airplanes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passangers",
                table: "Passangers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Passangers_ClientsId",
                table: "ClientFlight",
                column: "ClientsId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
