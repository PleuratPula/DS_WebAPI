using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class BaseAudit
    {
        // Properties
        public string InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public string LUB { get; set; }
        public DateTime LUD { get; set; }
        public int LUN { get; set; }

    }
}