namespace API.Domain.Entities
{
    public class DBFieldsBModel
    {
        public int ID { get; set; }
        public int FieldID { get; set; }
        public string? FieldName { get; set; }
        public int EntityID { get; set; }
        public string? EntityName { get; set; }
        public int AreaID { get; set; }
        public string? AreaName { get; set; }
    }
}
