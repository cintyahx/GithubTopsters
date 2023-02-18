using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miotto.GitHubTopsters.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GithubRepoOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubRepoOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GithubRepo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepoId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Stars = table.Column<long>(type: "bigint", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Forks = table.Column<long>(type: "bigint", nullable: false),
                    OpenIssues = table.Column<long>(type: "bigint", nullable: false),
                    Watchers = table.Column<long>(type: "bigint", nullable: false),
                    DefaultBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubRepo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GithubRepo_GithubRepoOwner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "GithubRepoOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubRepo_OwnerId",
                table: "GithubRepo",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GithubRepo");

            migrationBuilder.DropTable(
                name: "GithubRepoOwner");
        }
    }
}
