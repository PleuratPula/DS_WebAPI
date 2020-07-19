using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemeTeShperndara.Models
{
    public class Student
    {
        // Properties
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public DateTime Date { get; set; }
        public string Indeksi { get; set; }
        public Drejtimi drejtimi { get; set; }
        public Statusi statusi { get; set; }

        // Constructor
        public Student(string emri, string mbiemri, DateTime date, string indeksi, Drejtimi drejtimi, Statusi statusi)
        {
            Emri = emri;
            Mbiemri = mbiemri;
            Date = date;
            Indeksi = indeksi;
            this.drejtimi = drejtimi;
            this.statusi = statusi;
        }
    }

    // Enum Statusi
    public enum Statusi
    {
        Aktiv,
        Diplomuar,
        Regjistrurar,
        Suspenduar
    }
}