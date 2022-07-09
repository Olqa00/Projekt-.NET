using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_2.Models;

namespace Projekt_2.Pages.Products
{
    [Authorize(Roles = "User,Employee, Admin")]
    public class CartModel : MyPageModel
    {
        [FromQuery(Name = "id")]
        public int id { get; set; }
        public List<Product> productList;
        public List<Product> products;
        public int[] quantity;
        //public decimal[] sum;
        public decimal money = 0;
        public IActionResult AddToCart()
        {
            if (Request.Cookies["Shopping"] == null) Response.Cookies.Append("Shopping", id.ToString());
            else
            {
                var cookie = Request.Cookies["Shopping"];
                cookie += id.ToString();
                cookie = cookie.Trim('0');
                Response.Cookies.Append("Shopping", cookie);
            }
            return RedirectToPage("Cart");
        }
        public IActionResult OnPost()
        {
            Response.Cookies.Append("Shopping", "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            });
            return RedirectToPage("Cart");
        }
        public IActionResult OnGet(int? id)
        {
            LoadDB();
            products = productDB.List();
            var cookie = Request.Cookies["Shopping"];
            quantity = new int[products.Count + 2];
            if (cookie != null)
            {
                for (int i = 0; i < cookie.Length; i++) quantity[Convert.ToInt32(cookie[i]) - 48]++;
            }
            productList = new List<Product>();
            for (int i = 1; i < quantity.Count(); i++)
            {
                if (quantity[i] != 0) productList.Add(products.First(m => m.id == i));         
            }
            foreach (var p in productList)
            {
                money += (decimal)p.price * quantity[p.id];
                //sum = (decimal)p.price * quantity[p.id];
            }
            
            AddToCart();
            SaveDB();
            if (id != null) return RedirectToPage("IndexUser");
            else return Page();
        }

    }
}
