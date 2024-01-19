
﻿namespace API.Domain.Entities
﻿using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class DataSet
    {
        [Key]
        public int DataSetId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<DetFieldsOfDataSet> DetFieldsOfDataSets { get; set; }
    }
}
