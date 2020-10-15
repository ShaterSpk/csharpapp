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
    public class StudentTable
    {
        private DbConnection db = new DbConnection();

        public List<Osoba> GetStudent()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM student", db.Connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Osoba> students = new List<Osoba>();

            foreach (DataRow row in dt.Rows)
            {
                string jmeno = row["jmeno"].ToString();
                string prijmeni = row["prijmeni"].ToString();
                Osoba o1 = new Osoba(jmeno, prijmeni);

                students.Add(o1);
            }

            return students;
        }

        public Osoba FindStudent(string jmeno, string prijmeni) 
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 1 * FROM student where jmeno Like '"+ jmeno+ "%' or prijmeni Like '"+ prijmeni + "%'",db.Connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            DataRow row = dt.Rows[0];

            int id = int.Parse(row["id_student"].ToString());
            string jmenoStudenta = row["jmeno"].ToString();
            string prijmeniStudenta = row["prijmeni"].ToString();
            
            Osoba student = new Osoba( jmenoStudenta, prijmeniStudenta);
            student.Id = id;

            return student;    
        }

        public void NewStudent(Osoba osoba) 
        {

            String query = "INSERT INTO student(jmeno,prijmeni) Values (@jmeno,@prijmeni)";
            db.Connection.Open();
            SqlCommand command = new SqlCommand(query, db.Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.Parameters.Add("@jmeno", osoba.Jmeno.ToString() );
            command.Parameters.Add("@prijmeni",osoba.Prijmeni.ToString() );
            //adapter.InsertCommand = command;

            command.ExecuteNonQuery();
            db.Connection.Dispose();

             
        }
    }
}
