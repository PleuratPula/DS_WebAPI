using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class Useri
    {
        // Properties
        public string Username { get; set; }
        public string Fjalekalimi { get; set; }
        public Roli roli { get; set; }

        // last login ne DB me kriju ose 
        public DateTime LastLogin { get; set; }


        // Constructor
        public Useri(string username, string fjalekalimi, Roli roli, DateTime lastLogin)
        {
            Username = username;
            Fjalekalimi = fjalekalimi;
            this.roli = roli;
            LastLogin = lastLogin;
        }
    }
}