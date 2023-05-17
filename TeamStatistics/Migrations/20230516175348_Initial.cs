using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamStatistics.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JiraIssueProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "JiraIssueId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JiraIssueProducts",
                columns: table => new
                {
                    JiraIssueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    JiraProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JiraIssueProducts", x => new { x.JiraIssueId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_JiraIssueProducts_JiraIssues_JiraIssueId",
                        column: x => x.JiraIssueId,
                        principalTable: "JiraIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JiraIssueProducts_JiraProjects_JiraProjectId",
                        column: x => x.JiraProjectId,
                        principalTable: "JiraProjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JiraIssueProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "JiraIssueId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_JiraIssueId",
                table: "Products",
                column: "JiraIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraIssueProducts_JiraProjectId",
                table: "JiraIssueProducts",
                column: "JiraProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_JiraIssueProducts_ProductId",
                table: "JiraIssueProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_JiraIssues_JiraIssueId",
                table: "Products",
                column: "JiraIssueId",
                principalTable: "JiraIssues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_JiraIssues_JiraIssueId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "JiraIssueProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_JiraIssueId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "JiraIssueId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "JiraIssueProduct",
                columns: table => new
                {
                    JiraIssuesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JiraIssueProduct", x => new { x.JiraIssuesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_JiraIssueProduct_JiraIssues_JiraIssuesId",
                        column: x => x.JiraIssuesId,
                        principalTable: "JiraIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JiraIssueProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JiraIssueProduct_ProductsId",
                table: "JiraIssueProduct",
                column: "ProductsId");
        }
    }
}
