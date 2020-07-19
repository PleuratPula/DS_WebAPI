using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class Drejtimi
    {
        // Properties
        public string EmriDrejtimit { get; set; }
        public string Koment { get; set; }

        // Constructor
        public Drejtimi(string emriDrejtimit, string koment)
        {
            EmriDrejtimit = emriDrejtimit;
            Koment = koment;
        }
    }
}