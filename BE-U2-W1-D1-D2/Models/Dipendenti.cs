using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BE_U2_W1_D1_D2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio.")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il campo Indirizzo è obbligatorio.")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio.")]
        public string CodiceFiscale { get; set; }

        public bool Coniugato { get; set; }

        [Display(Name = "Numero Figli a Carico")]
        public int NumeroFigli { get; set; }

        public string Mansione { get; set; }
    }
}