using API.Application.Services;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using HotChocolate;
using HotChocolate.Types;
using System.Data;


namespace API.ReportsEngine.QueriesControllers
{
    public class DataSetMutationController
    {
        public class Dataset
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public List<DatasetDetailFields> DetailFields { get; set;}
        }

        public class DatasetDetailFields
        {
            public int ID { get; set; }
            public int FieldID { get; set; }
            public string? FieldName { get; set; }
            public int EntityID { get; set; }
            public string? EntityName { get; set; }
            public int AreaID { get; set; }
            public string AreaName { get; set; }
            public string Filter { get; set;}
            public string FilterType { get; set; }
            public string Order { get; set; }
        }

        public Dataset CreateDataset([Service] IDBFieldsBModelRepository datasetRepository, Dataset input)
        {
            var newDataset = new Dataset
            {
                ID = input.ID,
                Name = input.Name,
                Code = input.Code,
                Description = input.Description,
                DetailFields = input.DetailFields.Select(fieldInput => new DatasetDetailFields
                {
                    ID = fieldInput.ID,
                    FieldID = fieldInput.FieldID,
                    FieldName = fieldInput.FieldName,
                    EntityID = fieldInput.EntityID,
                    EntityName = fieldInput.EntityName,
                    AreaID = fieldInput.AreaID,
                    AreaName = fieldInput.AreaName,
                    Filter = fieldInput.Filter,
                    FilterType = fieldInput.FilterType,
                    Order = fieldInput.Order
                }).ToList(),
            };

            return newDataset;
        }
    }

}
