using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ALTER_TABLES_Fields_DetFieldsOfDataSet_DataSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetFieldsOfDataSet_Fields_CampoId",
                table: "DetFieldsOfDataSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Entities_EntidadId",
                table: "Fields");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Fields",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EntidadId",
                table: "Fields",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "CampoId",
                table: "Fields",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_EntidadId",
                table: "Fields",
                newName: "IX_Fields_EntityId");

            migrationBuilder.RenameColumn(
                name: "TipoFiltro",
                table: "DetFieldsOfDataSet",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Orden",
                table: "DetFieldsOfDataSet",
                newName: "FilterType");

            migrationBuilder.RenameColumn(
                name: "Filtro",
                table: "DetFieldsOfDataSet",
                newName: "Filter");

            migrationBuilder.RenameColumn(
                name: "CampoId",
                table: "DetFieldsOfDataSet",
                newName: "FieldId");

            migrationBuilder.RenameColumn(
                name: "DetCamposDeDataSetId",
                table: "DetFieldsOfDataSet",
                newName: "DetFieldsOfDataSetId");

            migrationBuilder.RenameIndex(
                name: "IX_DetFieldsOfDataSet_CampoId",
                table: "DetFieldsOfDataSet",
                newName: "IX_DetFieldsOfDataSet_FieldId");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "DataSets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "DataSets",
                newName: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_DetFieldsOfDataSet_Fields_FieldId",
                table: "DetFieldsOfDataSet",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Entities_EntityId",
                table: "Fields",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetFieldsOfDataSet_Fields_FieldId",
                table: "DetFieldsOfDataSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Entities_EntityId",
                table: "Fields");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Fields",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Fields",
                newName: "EntidadId");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "Fields",
                newName: "CampoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_EntityId",
                table: "Fields",
                newName: "IX_Fields_EntidadId");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "DetFieldsOfDataSet",
                newName: "TipoFiltro");

            migrationBuilder.RenameColumn(
                name: "FilterType",
                table: "DetFieldsOfDataSet",
                newName: "Orden");

            migrationBuilder.RenameColumn(
                name: "Filter",
                table: "DetFieldsOfDataSet",
                newName: "Filtro");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "DetFieldsOfDataSet",
                newName: "CampoId");

            migrationBuilder.RenameColumn(
                name: "DetFieldsOfDataSetId",
                table: "DetFieldsOfDataSet",
                newName: "DetCamposDeDataSetId");

            migrationBuilder.RenameIndex(
                name: "IX_DetFieldsOfDataSet_FieldId",
                table: "DetFieldsOfDataSet",
                newName: "IX_DetFieldsOfDataSet_CampoId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DataSets",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "DataSets",
                newName: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetFieldsOfDataSet_Fields_CampoId",
                table: "DetFieldsOfDataSet",
                column: "CampoId",
                principalTable: "Fields",
                principalColumn: "CampoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Entities_EntidadId",
                table: "Fields",
                column: "EntidadId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
