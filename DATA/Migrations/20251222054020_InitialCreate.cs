using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State_Chapter = table.Column<int>(type: "int", nullable: false),
                    State_HerbalistLevel = table.Column<int>(type: "int", nullable: false),
                    State_ForgeLevel = table.Column<int>(type: "int", nullable: false),
                    State_Fire = table.Column<bool>(type: "bit", nullable: false),
                    State_Horn = table.Column<bool>(type: "bit", nullable: false),
                    State_Crystal = table.Column<bool>(type: "bit", nullable: false),
                    State_Coral = table.Column<bool>(type: "bit", nullable: false),
                    State_Thunder = table.Column<bool>(type: "bit", nullable: false),
                    State_Metal = table.Column<bool>(type: "bit", nullable: false),
                    State_Feather = table.Column<bool>(type: "bit", nullable: false),
                    State_Venom = table.Column<bool>(type: "bit", nullable: false),
                    State_Ice = table.Column<bool>(type: "bit", nullable: false),
                    State_Vyraxen = table.Column<bool>(type: "bit", nullable: false),
                    State_Kharia = table.Column<bool>(type: "bit", nullable: false),
                    State_Toramat = table.Column<bool>(type: "bit", nullable: false),
                    State_Dygorax = table.Column<bool>(type: "bit", nullable: false),
                    State_Korowon = table.Column<bool>(type: "bit", nullable: false),
                    State_Orouxen = table.Column<bool>(type: "bit", nullable: false),
                    State_Felaxir = table.Column<bool>(type: "bit", nullable: false),
                    State_Morkraas = table.Column<bool>(type: "bit", nullable: false),
                    State_Ozew = table.Column<bool>(type: "bit", nullable: false),
                    State_Jekoros = table.Column<bool>(type: "bit", nullable: false),
                    State_Hurom = table.Column<bool>(type: "bit", nullable: false),
                    State_Tarragua = table.Column<bool>(type: "bit", nullable: false),
                    State_Hydar = table.Column<bool>(type: "bit", nullable: false),
                    State_Reikal = table.Column<bool>(type: "bit", nullable: false),
                    State_Sirkaaj = table.Column<bool>(type: "bit", nullable: false),
                    State_Mamuraak = table.Column<bool>(type: "bit", nullable: false),
                    State_Pazis = table.Column<bool>(type: "bit", nullable: false),
                    State_Nagarjas = table.Column<bool>(type: "bit", nullable: false),
                    State_Zekath = table.Column<bool>(type: "bit", nullable: false),
                    State_Zekalith = table.Column<bool>(type: "bit", nullable: false),
                    State_Taraska = table.Column<bool>(type: "bit", nullable: false),
                    State_Xitheros = table.Column<bool>(type: "bit", nullable: false),
                    State_CompletedQuests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State_Achievements = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Resources_Nillea = table.Column<int>(type: "int", nullable: false),
                    Resources_Tarmaret = table.Column<int>(type: "int", nullable: false),
                    Resources_Albalacea = table.Column<int>(type: "int", nullable: false),
                    Resources_Mellis = table.Column<int>(type: "int", nullable: false),
                    Resources_Anthemon = table.Column<int>(type: "int", nullable: false),
                    Resources_Saelicornia = table.Column<int>(type: "int", nullable: false),
                    Resources_Scales = table.Column<int>(type: "int", nullable: false),
                    Resources_Bones = table.Column<int>(type: "int", nullable: false),
                    Resources_Blood = table.Column<int>(type: "int", nullable: false),
                    Resources_Zima = table.Column<int>(type: "int", nullable: false),
                    Resources_Iride = table.Column<int>(type: "int", nullable: false),
                    Resources_Kobaureo = table.Column<int>(type: "int", nullable: false),
                    Resources_Fire = table.Column<int>(type: "int", nullable: false),
                    Resources_Horn = table.Column<int>(type: "int", nullable: false),
                    Resources_Coral = table.Column<int>(type: "int", nullable: false),
                    Resources_Crystal = table.Column<int>(type: "int", nullable: false),
                    Resources_Thunder = table.Column<int>(type: "int", nullable: false),
                    Resources_Metal = table.Column<int>(type: "int", nullable: false),
                    Resources_Feather = table.Column<int>(type: "int", nullable: false),
                    Resources_Venom = table.Column<int>(type: "int", nullable: false),
                    Resources_Ice = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkill",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkill", x => new { x.PlayerId, x.Id });
                    table.ForeignKey(
                        name: "FK_PlayerSkill_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_UserId",
                table: "Campaigns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CampaignId",
                table: "Players",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSkill");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
