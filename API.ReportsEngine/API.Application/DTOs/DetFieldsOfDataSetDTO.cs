namespace API.Application.DTOs
{
    public class DetFieldsOfDataSetDTO
    {
        public int DetFieldsOfDataSetId { get; set; }
        public int DataSetId { get; set; }
        public int FieldId { get; set; }
        public string FilterType { get; set; }
        public string Filter { get; set; }
        public string Order { get; set; }
    }
}
