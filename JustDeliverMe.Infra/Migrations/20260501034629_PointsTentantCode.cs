using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustDeliverMe.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PointsTentantCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Points",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Points",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "uq_points_tenant_code",
                table: "Points",
                columns: new[] { "TenantId", "Code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "uq_points_tenant_code",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Points");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Points",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
