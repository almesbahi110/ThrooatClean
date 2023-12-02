using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Stages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Processs",
                columns: table => new
                {
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessState = table.Column<int>(type: "int", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processs", x => x.ProcessId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStagess",
                columns: table => new
                {
                    ProcessStagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    StageId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Next = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStagess", x => x.ProcessStagesId);
                    table.ForeignKey(
                        name: "FK_ProcessStagess_Processs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processs",
                        principalColumn: "ProcessId");
                    table.ForeignKey(
                        name: "FK_ProcessStagess_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessRequests",
                columns: table => new
                {
                    ProcessRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessRequestState = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDescraption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ProcessStagesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRequests", x => x.ProcessRequestId);
                    table.ForeignKey(
                        name: "FK_ProcessRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_ProcessRequests_ProcessStagess_ProcessStagesId",
                        column: x => x.ProcessStagesId,
                        principalTable: "ProcessStagess",
                        principalColumn: "ProcessStagesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stages_EmployeeId",
                table: "Stages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequests_EmployeeId",
                table: "ProcessRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequests_ProcessStagesId",
                table: "ProcessRequests",
                column: "ProcessStagesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStagess_ProcessId",
                table: "ProcessStagess",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStagess_StageId",
                table: "ProcessStagess",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Employees_EmployeeId",
                table: "Stages",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Employees_EmployeeId",
                table: "Stages");

            migrationBuilder.DropTable(
                name: "ProcessRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProcessStagess");

            migrationBuilder.DropTable(
                name: "Processs");

            migrationBuilder.DropIndex(
                name: "IX_Stages_EmployeeId",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Stages");
        }
    }
}
