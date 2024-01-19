namespace API.Application.DTOs
{
    public class DataSetDTO
    {
        public int DataSetId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<DetFieldsOfDataSetDTO> DetFieldsOfDataSets { get; set; }

    }
}
