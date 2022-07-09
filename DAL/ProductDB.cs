using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Projekt_2.Models;
namespace Projekt_2.DAL
{
    public class ProductDB
    {
        private List<Product> products;
        ProductDataAccess productData = new ProductDataAccess();
        public void Load(string jsonProducts)
        {
            if (jsonProducts == null)
            {
                //products = Product.GetProducts();
                products = productData.GetProductsDB();
            }
            else
            {
                // products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                products = JsonSerializer.Deserialize<List<Product>>(jsonProducts);
            }
        }

        private int GetNextId()
        {
            if (products.Count == 0)
                return 1;
            int lastID = products[products.Count - 1].id;
            int newID = ++lastID;
            return newID;
        }
        public void Create(Product p)
        {
            p.id = GetNextId();
            products.Add(p);
        }
        public void Edit(Product p)
        {
            products.Find(x => x.id == p.id).name = p.name;
            products.Find(x => x.id == p.id).price = p.price;
        }
        public void Delete(int id)
        {
            products.Remove(products.Find(x => x.id == id));
            Fix();
        }
        public void Fix()
        {
            for (int i = 0; i < products.Count; i++)
            {
                products[i].id = i + 1;
            }
        }
        public string Save()
        {

            //return JsonConvert.SerializeObject(products);
            return JsonSerializer.Serialize(products);
        }
        public List<Product> List()
        {
            return products;
        }
    }
}
