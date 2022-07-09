using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projekt_2.Models;
namespace Projekt_2.DAL
{
    public class ProductDataAccess
    {
        string ProjectContext_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List <Product> GetProducts(int? id)
        {
            List<Product> ProductList = new List<Product>();
            SqlConnection con = new SqlConnection(ProjectContext_string);
            string sqlQuery = "SELECT * FROM Product p,ProductCategory pc WHERE p.id=pc.productID AND pc.categoryID= "+ id;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Product product = new Product();
                product.id = Convert.ToInt32(reader["id"]);
                product.producttypeID = Convert.ToInt32(reader["producttypeID"]);
                product.name = reader["name"].ToString();
                product.author = reader["author"].ToString();
                product.year = reader["year"].ToString();
                product.publishing_house = reader["publishing_house"].ToString();
                product.price = Convert.ToDecimal(reader["price"]); //tu z inta na coś innego!!! decimal
                product.description = reader["description"].ToString();
                product.img = reader["img"].ToString();

                ProductList.Add(product);
            }
            con.Close();
            return ProductList;
        }
        public Category GetCategory(int? id)
        {
            SqlConnection con = new SqlConnection(ProjectContext_string);
            string sqlQuery = "SELECT * FROM Category c, ProductCategory pc WHERE c.ID=pc.productID AND pc.productID=" + id ;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Category category = new Category();
            while (reader.Read())
            {
                category.ID = Convert.ToInt32(reader["ID"]);
                category.name = reader["name"].ToString();
            }
            con.Close();
            return category;
        }
        /*public ProductType GetProductType(int? id)
        {
            SqlConnection con = new SqlConnection(ProjectContext_string);
            string sqlQuery = "SELECT * FROM ProductType pt, Product p WHERE pt.id=p.id AND p.productID=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            ProductType productType = new ProductType();
            while (reader.Read())
            {
                productType.id = Convert.ToInt32(reader["id"]);
                productType.name = reader["name"].ToString();
            }
            con.Close();
            return productType;
        }*/
        public List<Product> GetProductsDB()
        {
            SqlConnection con = new SqlConnection(ProjectContext_string);
            string sqlQuery = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> ProductList = new List<Product>();
            
            while (reader.Read())
            {
                Product product = new Product();
                product.id = Convert.ToInt32(reader["ID"]);
                product.name = reader["name"].ToString();
                product.price = Convert.ToDecimal(reader["price"]);
                product.img = reader["img"].ToString();
                ProductList.Add(product);
            }
            con.Close();
            return ProductList;
        }
    }
}
