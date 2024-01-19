using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class DetFieldsOfDataSet
    {
        [Key]
        public int DetFieldsOfDataSetId { get; set; }
        public int DataSetId { get; set; }
        public int FieldId { get; set; }
        public string FilterType { get; set; }
        public string Filter { get; set; }
        public string Order { get; set; }

        public DataSet DataSet { get; set; }
        public Field Field { get; set; }

    }
}
