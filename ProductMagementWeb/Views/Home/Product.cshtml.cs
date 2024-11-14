using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//@model ProductMagementWeb.Views.Home.ProductModel // tutorial

namespace ProductMagementWeb.Views.Home
{
    public class ProductModel : PageModel
    {
        public List<ProductList2> listOfProduct = new List<ProductList2>();

        public void OnGet()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=testAPI;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductList", con);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    ProductList2 productList = new ProductList2();
                    productList.Id = da.GetGuid(0);
                    productList.ProductName = da.GetString(1);
                    productList.Catagory = (Catagories)da.GetInt32(2);
                    productList.Quality = (Qualities)da.GetInt32(3);
                    productList.ImportPrice = da.GetDouble(4);
                    productList.ExportPrice = da.GetDouble(5);

                    listOfProduct.Add(productList);
                }
                //con.Close();
                /*
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM ProductList";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductList productList = new ProductList();
                                productList.Id = reader.GetGuid(0);
                                productList.ProductName = reader.GetString(1);
                                productList.Catagory = (Catagories)reader.GetInt32(2);
                                productList.Quality = (Qualities)reader.GetInt32(3);
                                productList.ImportPrice = reader.GetDouble(4);
                                productList.ExportPrice = reader.GetDouble(5);
                                productList.DayCreated = reader.GetDateTime(6);

                                listOfProduct.Add(productList);
                            }
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    [Table("ProductList")]
    public class ProductList2
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("ProductName")]
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
}
