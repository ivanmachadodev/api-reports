using API.Domain.Entities;
using API.Infrastructure.Contracts;
using HotChocolate;
using HotChocolate.Types;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class CamposDBsQueryController
    {
        public IEnumerable<DBFieldsBModel> GetCamposDBs([Service] IDBFieldsBModelRepository CamposDBsRepository, int? id)
        {
            var listaCamposDBs = new List<DBFieldsBModel>()
            {
                new DBFieldsBModel() {ID=1, AreaID=1,AreaName="Area1", EntityID=1, EntityName="Entidad1", FieldID=1, FieldName="Campo1"},
                new DBFieldsBModel() {ID=2, AreaID=2,AreaName="Area2", EntityID=2, EntityName="Entidad2", FieldID=2, FieldName="Campo2"},
                new DBFieldsBModel() {ID=3, AreaID=3,AreaName="Area3", EntityID=3, EntityName="Entidad3", FieldID=3, FieldName="Campo3"},
                new DBFieldsBModel() {ID=4, AreaID=4,AreaName="Area4", EntityID=4, EntityName="Entidad4", FieldID=4, FieldName="Campo4"},
                new DBFieldsBModel() {ID=5, AreaID=5,AreaName="Area5", EntityID=5, EntityName="Entidad5", FieldID=5, FieldName="Campo5"},
                new DBFieldsBModel() {ID=6, AreaID=6,AreaName="Area6", EntityID=6, EntityName="Entidad6", FieldID=6, FieldName="Campo6"},
                new DBFieldsBModel() {ID=7, AreaID=7,AreaName="Area7", EntityID=7, EntityName="Entidad7", FieldID=7, FieldName="Campo7"},
                new DBFieldsBModel() {ID=8, AreaID=8,AreaName="Area8", EntityID=8, EntityName="Entidad8", FieldID=8, FieldName="Campo8"},
                new DBFieldsBModel() {ID=9, AreaID=9,AreaName="Area9", EntityID=9, EntityName="Entidad9", FieldID=9, FieldName="Campo9"},
            };

            if (id.HasValue)
            {
                var campoEncontrado = listaCamposDBs.FirstOrDefault(x => x.ID == id);
                return campoEncontrado != null ? new List<DBFieldsBModel> { campoEncontrado } : Enumerable.Empty<DBFieldsBModel>();
            }
            else
            {
                return listaCamposDBs;
            }
        }
    }
}
