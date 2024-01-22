using API.Domain.Entities;
using API.Infrastructure.Contracts;
using HotChocolate;
using HotChocolate.Types;
using static API.ReportsEngine.QueriesControllers.DataSetMutationController;

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
        public Dataset GetDatasets(int? id)
        {
            // Llenar la lista con 5 elementos de ejemplo
            var datasets = new List<Dataset>();
            for (int i = 1; i <= 5; i++)
            {
                datasets.Add(new Dataset
                {
                    ID = i,
                    Name = $"Dataset {i}",
                    Code = $"D{i}",
                    Description = $"Descripción del Dataset {i}",
                    DetailFields = new List<DatasetDetailFields>
            {
                new DatasetDetailFields
                {
                    ID = i,
                    FieldID = i * 10 + 101,
                    FieldName = $"Field{i * 10 + 1}",
                    EntityID = i * 10 + 201,
                    EntityName = $"Entity{i * 10 + 1}",
                    AreaID = i * 10 + 301,
                    AreaName = $"Area{i * 10 + 1}",
                    Filter = $"different",
                    Order = $"ascending"
                },
                new DatasetDetailFields
                {
                    ID = i + 1,
                    FieldID = i * 10 + 102,
                    FieldName = $"Field{i * 10 + 2}",
                    EntityID = i * 10 + 202,
                    EntityName = $"Entity{i * 10 + 2}",
                    AreaID = i * 10 + 302,
                    AreaName = $"Area{i * 10 + 2}",
                    Filter = $"begins with",
                    Order = $"descending"
                }
            }
                });
            }

            var datasetEncontrado = datasets.FirstOrDefault(x => x.ID == id);
            return datasetEncontrado;
        }
    }
}
