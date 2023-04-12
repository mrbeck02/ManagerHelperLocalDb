using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamStatistics.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JiraProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Domain = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JiraProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quarters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JiraIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    StoryPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRegressionBug = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false),
                    JiraProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JiraIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JiraIssues_JiraProjects_JiraProjectId",
                        column: x => x.JiraProjectId,
                        principalTable: "JiraProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JiraIssues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuarterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprints_Quarters_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commitments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DidComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    IncludeInData = table.Column<bool>(type: "INTEGER", nullable: false),
                    WasInitiallyCommitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false),
                    SprintId = table.Column<Guid>(type: "TEXT", nullable: false),
                    JiraIssueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commitments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commitments_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commitments_JiraIssues_JiraIssueId",
                        column: x => x.JiraIssueId,
                        principalTable: "JiraIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commitments_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JiraSupportIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WasInitiallyCommitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false),
                    SprintId = table.Column<Guid>(type: "TEXT", nullable: false),
                    JiraIssueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JiraSupportIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JiraSupportIssues_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JiraSupportIssues_JiraIssues_JiraIssueId",
                        column: x => x.JiraIssueId,
                        principalTable: "JiraIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JiraSupportIssues_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsPto = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHoliday = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false),
                    IssueStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommitmentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Commitments_CommitmentId",
                        column: x => x.CommitmentId,
                        principalTable: "Commitments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_IssueStatuses_IssueStatusId",
                        column: x => x.IssueStatusId,
                        principalTable: "IssueStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IssueStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "To Do" },
                    { 3, "In Progress" },
                    { 4, "Ready for Test" },
                    { 5, "In Test" },
                    { 6, "Ready for Release" },
                    { 7, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CARA" },
                    { 2, "Crisis Management" },
                    { 3, "Critical Resource Tracker" },
                    { 4, "EPMM" },
                    { 5, "OpenBeds" },
                    { 6, "Treatment Connection" },
                    { 7, "SMART on FHIR" },
                    { 8, "Availability API" },
                    { 9, "Referral API" },
                    { 10, "Cognito" },
                    { 11, "Launcher" },
                    { 12, "Dynatrace" },
                    { 13, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commitments_DeveloperId",
                table: "Commitments",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Commitments_JiraIssueId",
                table: "Commitments",
                column: "JiraIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Commitments_SprintId",
                table: "Commitments",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CommitmentId",
                table: "Entries",
                column: "CommitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_IssueStatusId",
                table: "Entries",
                column: "IssueStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraIssues_JiraProjectId",
                table: "JiraIssues",
                column: "JiraProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraIssues_ProductId",
                table: "JiraIssues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraSupportIssues_DeveloperId",
                table: "JiraSupportIssues",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraSupportIssues_JiraIssueId",
                table: "JiraSupportIssues",
                column: "JiraIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraSupportIssues_SprintId",
                table: "JiraSupportIssues",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_QuarterId",
                table: "Sprints",
                column: "QuarterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "JiraSupportIssues");

            migrationBuilder.DropTable(
                name: "Commitments");

            migrationBuilder.DropTable(
                name: "IssueStatuses");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "JiraIssues");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "JiraProjects");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Quarters");
        }
    }
}
