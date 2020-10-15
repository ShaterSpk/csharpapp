using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase.Backend.Data
{
    public class Osoba
    {
        private int id;
        private string jmeno;
        private string prijmeni;
        
        public int Id { get => id; set => id = value; }
        public string Jmeno { get => jmeno; set => jmeno = value; }
        public string Prijmeni { get => prijmeni; set => prijmeni = value; }

        public Osoba(string jmeno, string prijmeni)
        {
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
        }
    }
}
