using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class Lenda
    {
        // Properties
        public string EmriLendes { get; set; }
        public string Semestri { get; set; }
        public Drejtimi drejtimi { get; set; }


        // Constructor
        public Lenda(string emriLendes, string semestri, Drejtimi drejtimi)
        {
            EmriLendes = emriLendes;
            Semestri = semestri;
            this.drejtimi = drejtimi;
        }


    }
}