using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class Profesori
    {
        // Properties
        public string EmriProfesorit { get; set; }
        public Lenda lenda { get; set; }

        // Constructor
        public Profesori(string emriProfesorit, Lenda lenda)
        {
            EmriProfesorit = emriProfesorit;
            this.lenda = lenda;
        }

    }
}