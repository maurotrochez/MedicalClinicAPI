using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalClinic.DataAccess.Migrations
{
    public partial class ModelsMedicalClinicContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1L, "Medicina General" },
                    { 2L, "Odontología" },
                    { 3L, "Pediatría" },
                    { 4L, "Neurología" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "FirstName", "IdentificationNumber", "LastName" },
                values: new object[,]
                {
                    { 1L, "Juan", 1234L, "Perez" },
                    { 2L, "David", 12345L, "Trochez" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTypeId", "Date", "IsCancelled", "Notes", "PatientId" },
                values: new object[] { 1L, 1L, new DateTime(2020, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Consulta general", 1L });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTypeId", "Date", "IsCancelled", "Notes", "PatientId" },
                values: new object[] { 2L, 2L, new DateTime(2020, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Consulta general dientes", 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
