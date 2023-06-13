using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionSystem.EF.Migrations
{
    /// <inheritdoc />
    public partial class Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UserPoint",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeMissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    TypeMissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_TypeMissions_TypeMissionId",
                        column: x => x.TypeMissionId,
                        principalTable: "TypeMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: false),
                    StringAns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boolAns = table.Column<bool>(type: "bit", nullable: false),
                    Postr = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => new { x.UserId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_Answer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMissions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: false),
                    Complet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMissions", x => new { x.UserId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_UserMissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMissions_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_MissionId",
                table: "Answer",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_TypeMissionId",
                table: "Missions",
                column: "TypeMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMissions_MissionId",
                table: "UserMissions",
                column: "MissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "UserMissions");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "TypeMissions");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPoint",
                table: "AspNetUsers");
        }
    }
}
