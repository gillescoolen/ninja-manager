using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaManager.Domain.Migrations
{
  public partial class InitialCreate : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "gear",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Price = table.Column<int>(nullable: false),
            Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
            Strength = table.Column<int>(nullable: false),
            Intelligence = table.Column<int>(nullable: false),
            Agility = table.Column<int>(nullable: false),
            Slot = table.Column<string>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_gear", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "ninja",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
            Gold = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ninja", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "ninja_gear",
          columns: table => new
          {
            GearId = table.Column<int>(nullable: false),
            NinjaId = table.Column<int>(nullable: false),
            Price = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ninja_gear", x => new { x.GearId, x.NinjaId });
            table.ForeignKey(
                      name: "FK_ninja_gear_gear_GearId",
                      column: x => x.GearId,
                      principalTable: "gear",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ninja_gear_ninja_NinjaId",
                      column: x => x.NinjaId,
                      principalTable: "ninja",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_gear_Name",
          table: "gear",
          column: "Name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_ninja_Name",
          table: "ninja",
          column: "Name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_ninja_gear_NinjaId",
          table: "ninja_gear",
          column: "NinjaId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "ninja_gear");

      migrationBuilder.DropTable(
          name: "gear");

      migrationBuilder.DropTable(
          name: "ninja");
    }
  }
}
