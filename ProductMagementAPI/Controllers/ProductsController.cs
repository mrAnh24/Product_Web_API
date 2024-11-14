using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using ProductMagementAPI.Data;
using ProductMagementAPI.Models;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace ProductMagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductListDbContext dbc;

        public ProductsController(ProductListDbContext db)
        {
            dbc = db;
        }

        [HttpGet]
        [Route("/Product/List")]
        public IActionResult GetList()
        {
            return Ok(new { data = dbc.ProductList.ToList() });

        }

        [HttpPost]
        [Route("/Product/Insert")]
        public IActionResult InsertProduct(string productName, Catagories catagory, Qualities quality, double importPrice, double exportPrice)
        {
            ProductList pl = new ProductList();
            pl.Id = Guid.NewGuid();
            pl.ProductName = productName;
            pl.Catagory = catagory;
            pl.Quality = quality;
            pl.ImportPrice = importPrice;
            pl.ExportPrice = exportPrice;
            dbc.ProductList.Add(pl);
            dbc.SaveChanges();
            return Ok(new { pl });
        }

        [HttpOptions]
        [Route("/Product/Update")]
        public IActionResult UpdateProduct(string id, string productName, Catagories catagory, Qualities quality, double importPrice, double exportPrice)
        {
            ProductList pl = new ProductList();
            pl.Id = new Guid(id);
            pl.ProductName = productName;
            pl.Catagory = catagory;
            pl.Quality = quality;
            pl.ImportPrice = importPrice;
            pl.ExportPrice = exportPrice;
            dbc.ProductList.Update(pl);
            dbc.SaveChanges();
            return Ok(new { pl });

        }

        [HttpDelete]
        [Route("/Product/Delete")]
        public IActionResult DeleteProduct(string id)
        {
            ProductList pl = new ProductList();
            pl.Id = new Guid(id);
            dbc.ProductList.Remove(pl);
            dbc.SaveChanges();
            return Ok(new { pl });
        }
    }
}
