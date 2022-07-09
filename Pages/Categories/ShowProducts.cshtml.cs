using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_2.DAL;
using Projekt_2.Models;

namespace Projekt_2.Pages.Categories
{
    public class ShowProductsModel : PageModel
    {
        public List<Product> productList { get; set; }
        ProductDataAccess productData = new ProductDataAccess();
        public Category category { get; set; }
        public ProductType ProductType { get; set; }
        public void OnGet(int? id)
        {
            productList = productData.GetProducts(id);
            category = productData.GetCategory(id);
            //ProductType = productData.GetProductType(id);
            
        }
    }
}
