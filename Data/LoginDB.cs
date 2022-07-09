using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projekt_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_2.Data
{
    public class LoginDB
    {
        
        public static List<SiteUser> LoadUsers()
        {
            var con = new SqlConnection(MyAppData.Configuration.GetConnectionString("ProjectContext"));
            var sql = "SELECT * FROM SiteUser";
            var cmd = new SqlCommand(sql, con);
            con.Open();
            var data = cmd.ExecuteReader();
            List<SiteUser> usersList = new List<SiteUser>();
            while (data.Read())
            {
                SiteUser user = new SiteUser();
                user.login = data["login"].ToString().Replace(" ", "");
                user.password = data["password"].ToString().Replace(" ", "");
                user.confirmpassword=data["confirmpassword"].ToString().Replace(" ", "");
                user.Role = data["Role"].ToString().Replace(" ", "");
                usersList.Add(user);
            }
            data.Close();
            con.Close();
            return usersList;
        }
        public static string GetRole(SiteUser user)
        {
            string login,haslo,role;
            
            string ProjectContext_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ProjectContext_string);     
            string sqlQuery = "SELECT * FROM SiteUser";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                login = reader["login"].ToString().Replace(" ", "");
                haslo = reader["password"].ToString().Replace(" ", "");
                if(login==user.login && haslo==user.password)
                {
                    role = reader["Role"].ToString().Replace(" ", "");
                    return role;
                }
                
            }
            con.Close();
            reader.Close();
            string test = "User";
            return test;
        }
        /*public static bool GetLogin(SiteUser user)
        {
            string login, haslo, role;

            string ProjectContext_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ProjectContext_string);
            string sqlQuery = "SELECT * FROM SiteUser";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                login = reader["login"].ToString().Replace(" ", "");
                haslo = reader["password"].ToString().Replace(" ", "");
                if (login == user.login && haslo == user.password)
                {
                    role = reader["Role"].ToString().Replace(" ", "");
                    return role;
                }

            }
            con.Close();
            reader.Close();
            string test = "User";
            return test;
        */
    }
}
