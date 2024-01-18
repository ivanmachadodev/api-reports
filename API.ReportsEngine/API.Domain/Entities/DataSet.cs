using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class DataSet
    {
        [Key]
        public int DataSetId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<DetFieldsOfDataSet> DetFieldsOfDataSets { get; set; }
    }
}
