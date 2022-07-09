using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projekt_2.Models;
using Projekt_2.Data;
namespace Projekt_2.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string Message { get; set; }
        [BindProperty]
        public SiteUser user { get; set; }
        public LoginDB logindb { get; set; }
        public UserLoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<SiteUser> users;
        private bool ValidateUser(SiteUser user)
        {
            int id, x = 0;
            string Login, password, Role;

            string hashedLogin = Hash.HashPassword(user.password);
            SiteUser newUser = new SiteUser(); //nowy obiekt 
            newUser.login = user.login; // normalny login
            newUser.password = hashedLogin; //zahashowane has³o
            //newUser.Role = user.Role;
            List<SiteUser> users = new List<SiteUser>();
            string sqlDB = _configuration.GetConnectionString("ProjectContext");
            SqlConnection con = new SqlConnection(sqlDB);
            string sql = "Select * from SiteUser";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder htmlStr = new StringBuilder("");
            while (reader.Read())
            {
                id = Int32.Parse(reader["id"].ToString());
                Login = reader["login"].ToString();
                password = reader["password"].ToString();
                Role = reader["Role"].ToString(); // tu dzia³a
                // ni¿ej ju¿ nie
                users.Add(new SiteUser { id = id, Role = Role, login = String.Concat(Login.Where(c => !Char.IsWhiteSpace(c))), password = String.Concat(password.Where(c => !Char.IsWhiteSpace(c))) });
            }
            reader.Close(); con.Close();
            foreach (SiteUser user1 in users)//porównywanie nowego obiektu do tego, który jest w bazie
            {
                if ((newUser.login == user1.login) && (newUser.password == user1.password))
                {
                    x = 1;
                }
                
            }
            if (x == 1)
            {
                user.Role = LoginDB.GetRole(newUser);
                return true;
            }
                
            else
                return false;

            /*if ((user.userName == "admin") && (user.password == "abc"))
                return true;
            else
                return false;*/
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var redirectTarget = string.Empty;
            if (ValidateUser(user))
            {
                var claims = new List<Claim>()
                 {
                  new Claim(ClaimTypes.Name, user.login),
                  new Claim(ClaimTypes.Role, user.Role)
                 };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                return Page(); //TUTAJ!!!!!!!!!!!!!!!!!!!!
                               //return RedirectToPage(returnUrl);

            }
            return Page();
        }
        public void OnGet()
        {
        }

    }
}
