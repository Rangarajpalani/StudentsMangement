using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsMangement.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clazz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCount = table.Column<int>(type: "int", nullable: false),
                    StaffCount = table.Column<int>(type: "int", nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clazz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourzesId = table.Column<int>(type: "int", nullable: true),
                    ClazzesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Clazz_ClazzesId",
                        column: x => x.ClazzesId,
                        principalTable: "Clazz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_Courze_CourzesId",
                        column: x => x.CourzesId,
                        principalTable: "Courze",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClazzStaff",
                columns: table => new
                {
                    ClazzesId = table.Column<int>(type: "int", nullable: false),
                    StaffsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClazzStaff", x => new { x.ClazzesId, x.StaffsId });
                    table.ForeignKey(
                        name: "FK_ClazzStaff_Clazz_ClazzesId",
                        column: x => x.ClazzesId,
                        principalTable: "Clazz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClazzStaff_Staff_StaffsId",
                        column: x => x.StaffsId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourzeStaff",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StaffsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourzeStaff", x => new { x.DepartmentId, x.StaffsId });
                    table.ForeignKey(
                        name: "FK_CourzeStaff_Courze_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Courze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourzeStaff_Staff_StaffsId",
                        column: x => x.StaffsId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClazzStaff_StaffsId",
                table: "ClazzStaff",
                column: "StaffsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourzeStaff_StaffsId",
                table: "CourzeStaff",
                column: "StaffsId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClazzesId",
                table: "Student",
                column: "ClazzesId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourzesId",
                table: "Student",
                column: "CourzesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClazzStaff");

            migrationBuilder.DropTable(
                name: "CourzeStaff");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Clazz");

            migrationBuilder.DropTable(
                name: "Courze");
        }
    }
}
