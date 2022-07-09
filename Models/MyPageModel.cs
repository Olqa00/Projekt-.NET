using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_2.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Projekt_2.Models
{
    public class MyPageModel : PageModel
    {
        public ProductDB productDB;
        public string jsonProductDB { get; set; }
        public MyPageModel()
        {
            productDB = new ProductDB();
        }
        public void LoadDB()
        {
            jsonProductDB = HttpContext.Session.GetString("jsonProductDB");
            productDB.Load(jsonProductDB);
        }
        public void SaveDB()
        {
            jsonProductDB = productDB.Save();
            HttpContext.Session.SetString("jsonProductDB", jsonProductDB);
        }

    }
}
