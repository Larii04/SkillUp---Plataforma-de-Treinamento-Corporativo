using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    Thumbnail = table.Column<string>(type: "text", nullable: true),
                    Publicado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    Papel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modulos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Enunciado = table.Column<string>(type: "text", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    Explicacao = table.Column<string>(type: "text", nullable: true),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questoes_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CaminhoPdf = table.Column<string>(type: "text", nullable: false),
                    HashVerificacao = table.Column<string>(type: "text", nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificados_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insignias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insignias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insignias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pontuacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pontos = table.Column<int>(type: "integer", nullable: false),
                    Motivo = table.Column<string>(type: "text", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontuacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontuacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressoCursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Percentual = table.Column<decimal>(type: "numeric", nullable: false),
                    Concluido = table.Column<bool>(type: "boolean", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressoCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressoCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressoCursos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TentativasQuestionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalQuestoes = table.Column<int>(type: "integer", nullable: false),
                    Acertos = table.Column<int>(type: "integer", nullable: false),
                    Nota = table.Column<decimal>(type: "numeric", nullable: false),
                    JsonRespostas = table.Column<string>(type: "text", nullable: true),
                    DataTentativa = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TentativasQuestionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TentativasQuestionario_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TentativasQuestionario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    UrlConteudo = table.Column<string>(type: "text", nullable: true),
                    ConteudoTexto = table.Column<string>(type: "text", nullable: true),
                    RequerQuestionario = table.Column<bool>(type: "boolean", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    MinutosEstimados = table.Column<int>(type: "integer", nullable: true),
                    ModuloId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licoes_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    Correta = table.Column<bool>(type: "boolean", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcoes_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressoLicoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Concluida = table.Column<bool>(type: "boolean", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    LicaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressoLicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressoLicoes_Licoes_LicaoId",
                        column: x => x.LicaoId,
                        principalTable: "Licoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressoLicoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_CursoId",
                table: "Certificados",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_UsuarioId",
                table: "Certificados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Insignias_UsuarioId",
                table: "Insignias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Licoes_ModuloId",
                table: "Licoes",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_CursoId",
                table: "Modulos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Opcoes_QuestaoId",
                table: "Opcoes",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pontuacoes_UsuarioId",
                table: "Pontuacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressoCursos_CursoId",
                table: "ProgressoCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressoCursos_UsuarioId",
                table: "ProgressoCursos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressoLicoes_LicaoId",
                table: "ProgressoLicoes",
                column: "LicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressoLicoes_UsuarioId",
                table: "ProgressoLicoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_CursoId",
                table: "Questoes",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TentativasQuestionario_CursoId",
                table: "TentativasQuestionario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TentativasQuestionario_UsuarioId",
                table: "TentativasQuestionario",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Insignias");

            migrationBuilder.DropTable(
                name: "Opcoes");

            migrationBuilder.DropTable(
                name: "Pontuacoes");

            migrationBuilder.DropTable(
                name: "ProgressoCursos");

            migrationBuilder.DropTable(
                name: "ProgressoLicoes");

            migrationBuilder.DropTable(
                name: "TentativasQuestionario");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Licoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
