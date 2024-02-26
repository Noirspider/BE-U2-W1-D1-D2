using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE_U2_W1_D1_D2.Models
{
    public class Pagamenti
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime PeriodoPagamento { get; set; }
        public decimal Ammontare { get; set; }
        public string Tipo { get; set; } // stipendio o acconto
    }
}