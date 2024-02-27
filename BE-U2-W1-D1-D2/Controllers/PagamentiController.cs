using BE_U2_W1_D1_D2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace BE_U2_W1_D1_D2.Controllers
{
    public class PagamentiController : Controller
    {
        // GET: Pagamenti
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            List<Pagamenti> pagamenti = new List<Pagamenti>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Pagamenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pagamenti p = new Pagamenti();
                    p.IDPagamento = Convert.ToInt32(reader["IDPagamento"]);
                    p.IDDipendente = Convert.ToInt32(reader["IDDipendente"]);
                    p.DataPagamento = Convert.ToDateTime(reader["DataPagamento"]);
                    p.Ammontare = Convert.ToDecimal(reader["Ammontare"]);
                    pagamenti.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }   

            return View(pagamenti);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Pagamenti p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "INSERT INTO Pagamenti (IDDipendente, DataPagamento, Ammontare) VALUES (@IDDipendente, @DataPagamento, @Ammontare)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDDipendente", p.IDDipendente);
                cmd.Parameters.AddWithValue("@DataPagamento", p.DataPagamento);
                cmd.Parameters.AddWithValue("@Ammontare", p.Ammontare);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return RedirectToAction("Index");
        }   
    }
}