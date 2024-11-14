using ProductMagementWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using ProductMagementWeb.ViewModels;
using ProductMagementWeb.Views.Home;
using System.Data.SqlClient;

namespace ProductMagementWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult Product()
        {
            return View();
        }*/

        /*public IActionResult Product()
        { 
            ProductModel list = new ();
            return View(list);

            //var products = ProductModel.listOfProduct;   
            //return View(products);
        }*/

        /*public IActionResult Product()
        {
            return View();
        }*/

        /*public async Task<IActionResult> Product(Views.Home.ProductList model)
        {
            if (ModelState.IsValid)
            {

                Views.Home.ProductList productList = new()
                {
                    Id = model.Id,
                    ProductName = model.ProductName,
                    Catagory = model.Catagory,
                    Quality = model.Quality,
                    ImportPrice = model.ImportPrice,
                    ExportPrice = model.ExportPrice,
                };
            }
            return View(model);
        }*/

        public IActionResult Product()
        {            
            SqlConnection con = new SqlConnection("Server=.;Database=testAPI;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProductList", con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                ProductList productList = new ProductList();
                productList.Id = da.GetGuid(0);
                productList.ProductName = da.GetString(1);
                productList.Catagory = (Models.Catagories)da.GetInt32(2);
                productList.Quality = (Models.Qualities)da.GetInt32(3);
                productList.ImportPrice = da.GetDouble(4);
                productList.ExportPrice = da.GetDouble(5);

                //Models.ProductModel.listOfProduct.Add(productList);

            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        public IActionResult Product2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
