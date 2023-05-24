using MokriLug.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MokriLug.Controllers
{
    public class HomeController : Controller
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; user id=root; database=mokrilugkaw");
        public ActionResult Index()
        {

            List<UserViewModel> users = new List<UserViewModel>();

            conn.Open();

            string sql = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                users.Add(new UserViewModel()
                {
                    Username = dr["username"].ToString(),
                    Won = (int?)dr["won"],
                    Lost = (int?)dr["lost"]
                });
            }
            return View(users);
        }
    }
}