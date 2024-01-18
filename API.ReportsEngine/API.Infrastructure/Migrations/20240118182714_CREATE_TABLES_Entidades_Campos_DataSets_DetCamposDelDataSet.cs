using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CREATE_TABLES_Entidades_Campos_DataSets_DetCamposDelDataSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CamposDBs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldID = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityID = table.Column<int>(type: "int", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamposDBs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    DataSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.DataSetId);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    EntidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.EntidadId);
                    table.ForeignKey(
                        name: "FK_Entidades_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    CampoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.CampoId);
                    table.ForeignKey(
                        name: "FK_Campos_Entidades_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidades",
                        principalColumn: "EntidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetCamposDelDataSet",
                columns: table => new
                {
                    DetCamposDeDataSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSetId = table.Column<int>(type: "int", nullable: false),
                    CampoId = table.Column<int>(type: "int", nullable: false),
                    TipoFiltro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Filtro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetCamposDelDataSet", x => x.DetCamposDeDataSetId);
                    table.ForeignKey(
                        name: "FK_DetCamposDelDataSet_Campos_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campos",
                        principalColumn: "CampoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetCamposDelDataSet_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSets",
                        principalColumn: "DataSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campos_EntidadId",
                table: "Campos",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_DetCamposDelDataSet_CampoId",
                table: "DetCamposDelDataSet",
                column: "CampoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetCamposDelDataSet_DataSetId",
                table: "DetCamposDelDataSet",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_AreaId",
                table: "Entidades",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamposDBs");

            migrationBuilder.DropTable(
                name: "DetCamposDelDataSet");

            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropTable(
                name: "Entidades");
        }
    }
}
