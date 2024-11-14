using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductMagementWeb.Views.Home
{
    public class CreateModel : PageModel
    {
        public ProductList2 listOfProduct = new ProductList2();
        //public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            listOfProduct.ProductName = Request.Form["ProductName"];
            listOfProduct.Catagory = (Catagories)int.Parse(Request.Form["Catagory"]);
            listOfProduct.Quality = (Qualities)int.Parse(Request.Form["Quality"]);
            listOfProduct.ImportPrice = int.Parse(Request.Form["ImportPrice"]);
            listOfProduct.ExportPrice = int.Parse(Request.Form["ExportPrice"]);

            /*if(listOfProduct.ProductName.Length == 0 || listOfProduct.Catagory == null || listOfProduct.Quality == null || listOfProduct.ImportPrice == null || listOfProduct.ExportPrice == null)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //listOfProduct.ProductName = ""; listOfProduct.Catagory = ""; listOfProduct.Quality = ""; listOfProduct.ImportPrice = ; listOfProduct.ExportPrice = "";
            */successMessage = "New product added successfully";
        }
    }
}
