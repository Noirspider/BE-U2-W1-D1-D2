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
            string connectionString = ConfigurationManager.ConnectionStrings["JurassicEdil"].ConnectionString;
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
                    d.IDDipendente = Convert.ToInt32(reader["IDDipendente"]);
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
            return View();
        }
    }
}