using Microsoft.EntityFrameworkCore.Migrations;

namespace JovemProgramadorMvc.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Contato = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
