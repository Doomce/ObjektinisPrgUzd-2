using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp5.Registration;

namespace WindowsFormsApp5
{
    public partial class Prof : Form
    {
        public Prof(Professor user)
        {
            InitializeComponent();
            listBox1.Items.AddRange(user.GetAllowedSubjects().ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size;
           
            //string path = @"e:\\temp\\data.txt";
            //
            //
            //if (!File.Exists(path)) {
            //    File.WriteAllText(path, name.Text + " " + surname.Text + " " + subject.Text + " " + grade.Text);
            //}
            //
            //else { 
            //    string [] lines = File.ReadAllLines(path);
            //    size = lines.Length;
            //    size++;
            //    string[] new_lines = new string[size];
            //    for (int i = 0; i < size - 1; i++) new_lines[i] = lines[i];
            //    new_lines[size - 1] = name.Text + " " + surname.Text + " " + subject.Text + " " + grade.Text;
            //    File.WriteAllLines(path, new_lines);
            //}


            if (String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(surname.Text) ||
                String.IsNullOrEmpty(listBox1.Text) || String.IsNullOrEmpty(grade.Text))
            {
                MessageBox.Show("Bloga formos ivestis");
                return;
            }

            string subject = (string) listBox1.SelectedItem;
            

            int pt = 0;
            try
            {
                pt = Int32.Parse(grade.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bloga pazymio ivestis.");
            }

            Student student;
            try
            {
                student = (Student) Program.Users.Find(user => 
                    user.Name.Equals(name.Text) && user.SurName.Equals(surname.Text));
                string text = student.Name;
                Program.Users.Remove(student);
            }
            catch (Exception)
            {
                student = new Student(name.Text, surname.Text);
            }
            student.SetSubjectGrade(subject, pt);
            Program.Users.Add(student);
            MessageBox.Show($"Parašei pažymį {name.Text} {surname.Text} -> {subject} ({pt})");
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
