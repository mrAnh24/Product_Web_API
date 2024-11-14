using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace ProductMagementAPI.Models
{
    public class ProductList
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("ProductName")]
        [Required]
        public string ProductName { get; set; }
        [Column("Catagory")]
        public Catagories Catagory { get; set; }
        [Column("Quality")]
        public Qualities Quality { get; set; }
        [Column("ImportPrice")]
        public double ImportPrice { get; set; }
        [Column("ExportPrice")]
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

    /*public IActionResult ListOfProduct(int id)
    {
        ProductList item = new ProductList();
        item.ProductName = 
    }*/
}
