using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE_U2_W1_D1_D2.Models;
using System.Data.SqlClient;


namespace BE_U2_W1_D1_D2.Controllers
{
    public class DipendentiController : Controller
    {
        // GET: Dipendenti
        public ActionResult Index()
        {
            List<Dipendenti> dipendente = new List<Dipendenti>();
            string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dipendenti d = new Dipendenti();
                    d.Nome = reader["Nome"].ToString();
                    d.Cognome = reader["Cognome"].ToString();
                    d.Indirizzo = reader["Indirizzo"].ToString();
                    d.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    d.Coniugato = Convert.ToBoolean(reader["Coniugato"]);
                    d.NFigliACarico = Convert.ToInt32(reader["NFigliACarico"]);
                    d.Mansione = reader["Mansione"].ToString();
                    dipendente.Add(d);
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
            return View(dipendente);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Dipendenti d)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, NFigliACarico, Mansione) VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NFigliACarico, @Mansione)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", d.Nome);
                cmd.Parameters.AddWithValue("@Cognome", d.Cognome);
                cmd.Parameters.AddWithValue("@Indirizzo", d.Indirizzo);
                cmd.Parameters.AddWithValue("@CodiceFiscale", d.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Coniugato", d.Coniugato);
                cmd.Parameters.AddWithValue("@NFigliACarico", d.NFigliACarico);
                cmd.Parameters.AddWithValue("@Mansione", d.Mansione);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("ERROR: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return RedirectToAction("Index");
        }

    }
}