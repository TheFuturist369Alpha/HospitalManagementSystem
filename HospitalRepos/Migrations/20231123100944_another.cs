using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalRepos.Migrations
{
    public partial class another : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Hospitals_HospitalPropId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_HospitalPropId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "HospitalPropId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "HospitalPropId1",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HospitalPropId1",
                table: "Rooms",
                column: "HospitalPropId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hospitals_HospitalPropId1",
                table: "Rooms",
                column: "HospitalPropId1",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hospitals_HospitalPropId1",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HospitalPropId1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HospitalPropId1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "HospitalPropId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_HospitalPropId",
                table: "Contacts",
                column: "HospitalPropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Hospitals_HospitalPropId",
                table: "Contacts",
                column: "HospitalPropId",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }
    }
}
