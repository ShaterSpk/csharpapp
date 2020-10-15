using SchoolDatabase.Backend;
using SchoolDatabase.Backend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDatabase
{
    public partial class Form1 : Form
    {
        private SubjectTable subjectTable = new SubjectTable();
        private StudentTable studentTable = new StudentTable();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Osoba foundStudent = studentTable.FindStudent(textBox1.Text, textBox2.Text);
            List<Predmet> foundSubjects = subjectTable.FindSubject(foundStudent);

            string subjectText="";

            foreach (Predmet predmet in foundSubjects)
            {
              subjectText+=predmet.Nazev.ToString()+ " " +predmet.Ucitel.Jmeno+ " "+ predmet.Ucitel.Prijmeni + " " + System.Environment.NewLine;

            }
            
            
           MessageBox.Show("Nalezena osoba :"+foundStudent.Jmeno+ " " + foundStudent.Prijmeni + ":"+System.Environment.NewLine + subjectText);
            

            
        }

        private void vytvořeníStudentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormStudent myForm = new FormStudent();

            myForm.ShowDialog();
        }
    }
}
