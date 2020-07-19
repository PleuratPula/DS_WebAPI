using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class Provimi
    {

        // Properties
        public int IdStudentit { get; set; }
        public Lenda lenda { get; set; }
        public Profesori profesori { get; set; }
        public int Piket { get; set; }
        public int Nota { get; set; }

        // Constructor
        public Provimi(int idStudentit, Lenda lenda, Profesori profesori, int piket, int nota)
        {
            IdStudentit = idStudentit;
            this.lenda = lenda;
            this.profesori = profesori;
            Piket = piket;
            Nota = nota;
        }


    }
}