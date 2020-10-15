using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase.Backend.Data
{
    public class Predmet
    {
        private int id;
        private string nazev;
        private Osoba ucitel;

        public int Id { get => id; set => id = value; }
        public string Nazev { get => nazev; set => nazev = value; }
        public Osoba Ucitel { get => ucitel; set => ucitel = value; }

        public Predmet(string nazev)
        {
            Nazev = nazev;
        }
    
    
    }

}
