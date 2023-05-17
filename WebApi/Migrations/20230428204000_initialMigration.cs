using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Skill = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Position" },
                values: new object[] { 1, "Enang Lawrence", "midfielder" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Position" },
                values: new object[] { 2, "Banwo Omosan", "midfielder" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Position" },
                values: new object[] { 3, "Awase Faustina", "defender" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Position" },
                values: new object[] { 4, "Awase Clara", "forwarder" });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 1, 1, "strength", 70 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 2, 1, "stamina", 90 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 3, 2, "strength", 50 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 4, 2, "stamina", 2 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 5, 3, "defense", 60 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 6, 3, "speed", 80 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 7, 4, "attack", 20 });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "Id", "PlayerId", "Skill", "Value" },
                values: new object[] { 8, 4, "speed", 70 });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_PlayerId",
                table: "PlayerSkills",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSkills");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");
        }
    }
}
