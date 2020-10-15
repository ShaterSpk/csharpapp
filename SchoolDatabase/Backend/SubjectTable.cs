using SchoolDatabase.Backend.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase.Backend
{
    public class SubjectTable
    {
        private DbConnection db = new DbConnection();

        public List<Predmet> GetPredmet()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT nazev,ucitel.jmeno,ucitel.prijmeni FROM predmet,ucitel where predmet.id_ucitel=ucitel.id_ucitel", db.Connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Predmet> subjects = new List<Predmet>();

            foreach (DataRow row in dt.Rows)
            {
                string nazev = row["nazev"].ToString();
                string jmeno = row["jmeno"].ToString();
                string prijmeni = row["prijmeni"].ToString();

                Predmet subject  = new Predmet(nazev);
                Osoba ucitel = new Osoba(jmeno, prijmeni);
                subject.Ucitel = ucitel;

                subjects.Add(subject);
            }
            return subjects;
        }


        public List<Predmet> FindSubject(Osoba student) 
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select nazev,jmeno,prijmeni from student_predmet " +
                "JOIN predmet on predmet.id_predmet = student_predmet.id_predmet " +
                "JOIN ucitel on ucitel.id_ucitel = predmet.id_ucitel " +
                "where student_predmet.id_student = "+ student.Id, db.Connection);
            DataTable dt = new DataTable();
            
            adapter.Fill(dt);

            List<Predmet> subjects = new List<Predmet>();

            foreach (DataRow row in dt.Rows)
            {
                string nazev = row["nazev"].ToString();
                string jmeno = row["jmeno"].ToString();
                string prijmeni = row["prijmeni"].ToString();

                Predmet subject = new Predmet(nazev);
                Osoba ucitel = new Osoba(jmeno, prijmeni);
                subject.Ucitel = ucitel;

                subjects.Add(subject);
            }

            return subjects;
        }
    }

    
}
