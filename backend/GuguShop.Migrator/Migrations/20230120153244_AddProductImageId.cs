using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuguShop.Migrator.Migrations
{
    public partial class AddProductImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Product");
        }
    }
}
