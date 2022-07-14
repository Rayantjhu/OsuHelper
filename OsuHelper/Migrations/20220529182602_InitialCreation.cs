using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OsuHelper.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Replays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Filename = table.Column<string>(type: "TEXT", nullable: true),
                    Ruleset = table.Column<int>(type: "INTEGER", nullable: false),
                    OsuVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    BeatmapMD5Hash = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: false),
                    ReplayMD5Hash = table.Column<string>(type: "TEXT", nullable: false),
                    Count300 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Count100 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Count50 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    CountGeki = table.Column<ushort>(type: "INTEGER", nullable: false),
                    CountKatu = table.Column<ushort>(type: "INTEGER", nullable: false),
                    CountMiss = table.Column<ushort>(type: "INTEGER", nullable: false),
                    ReplayScore = table.Column<int>(type: "INTEGER", nullable: false),
                    Combo = table.Column<ushort>(type: "INTEGER", nullable: false),
                    PerfectCombo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Mods = table.Column<int>(type: "INTEGER", nullable: false),
                    ReplayTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReplayLength = table.Column<int>(type: "INTEGER", nullable: false),
                    Seed = table.Column<int>(type: "INTEGER", nullable: false),
                    OnlineId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replays", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replays");
        }
    }
}
