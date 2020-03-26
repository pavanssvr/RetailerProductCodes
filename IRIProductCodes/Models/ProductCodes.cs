using Newtonsoft.Json;
using System;

namespace Models
{
    public class ProductCodes
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CodeType { get; set; }
        public string Code { get; set; }
        [JsonIgnore]
        public DateTime DateReceived { get; set; }
        [JsonIgnore]
        public int RowNumber { get; set; }
    }
}
