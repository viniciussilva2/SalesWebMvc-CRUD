using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class QuintAlt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
