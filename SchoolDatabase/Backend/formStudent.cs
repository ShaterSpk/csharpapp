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

namespace SchoolDatabase.Backend
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
            SubjectTable subjectTable = new SubjectTable();
            List<Predmet> listSubject=subjectTable.GetPredmet();

            foreach (Predmet predmet in listSubject ) 
            {
                string nazev = predmet.Nazev;
                checkedListBox1.Items.Add(nazev.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Osoba osoba = new Osoba(textBox1.Text,textBox2.Text);
            StudentTable studentTable = new StudentTable();
            studentTable.NewStudent(osoba);
        }
    }
}
