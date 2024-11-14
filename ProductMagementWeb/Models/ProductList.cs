using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace ProductMagementWeb.Models
{
    public class ProductList
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Catagories Catagory { get; set; }
        public Qualities Quality { get; set; }
        public double ImportPrice { get; set; }
        public double ExportPrice { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Qualities
    {
        Low, Medium, High
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Catagories
    {
        Small, Medium, Large
    }
}
