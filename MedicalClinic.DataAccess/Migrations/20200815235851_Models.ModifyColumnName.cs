using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalClinic.DataAccess.Migrations
{
    public partial class ModelsModifyColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointMentType",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointMentType",
                table: "Appointments",
                newName: "AppointmentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AppointMentType",
                table: "Appointments",
                newName: "IX_Appointments_AppointmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId",
                principalTable: "AppointmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentTypeId",
                table: "Appointments",
                newName: "AppointMentType");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                newName: "IX_Appointments_AppointMentType");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointMentType",
                table: "Appointments",
                column: "AppointMentType",
                principalTable: "AppointmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
