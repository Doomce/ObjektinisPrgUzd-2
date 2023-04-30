using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Registration;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(loginName.Text) || String.IsNullOrEmpty(loginSurname.Text)
                || String.IsNullOrEmpty(loginPassw.Text))
            {
                MessageBox.Show("Blogai įvesta forma.");
                return;
            }
            
            try
            {
                var users = Program.Users.Find(user => 
                    user.Name.Equals(loginName.Text) && user.SurName.Equals(loginSurname.Text));
                string username = users.Name;
                if (!users.HasPassword()) throw new Exception();

                if (!users.CheckPasssword(loginPassw.Text))
                {
                    MessageBox.Show("Neteisingas slaptažodis.");
                    return;
                }
                if(radioButton1.Checked)
                {
                    Prof f = new Prof((Professor) users);
                    f.Show();
                    return;
                }

                MessageBox.Show(((Student)users).GetGrades());
            }
            catch (Exception)
            {
                MessageBox.Show("Nepavyko surasti tokio vartotojo.");
            }
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(loginName.Text) || String.IsNullOrEmpty(loginSurname.Text)
                                                     || String.IsNullOrEmpty(loginPassw.Text))
            {
                MessageBox.Show("Blogai įvesta forma.");
                return;
            }
            
            try
            {
                var users = Program.Users.Find(user => 
                    user.Name.Equals(loginName.Text) && user.SurName.Equals(loginSurname.Text));
                string username = users.Name;
                if (users.HasPassword())
                {
                    MessageBox.Show("Vartotojas uzregistruotas");
                    return;
                }
                users.SetPassword(loginPassw.Text);
                MessageBox.Show("Toks vartotojas jau užregistruotas.");
                return;
            }
            catch (Exception)
            {
                User newUser;
                if(radioButton2.Checked)
                {
                    newUser = new Student(loginName.Text, loginSurname.Text);
                }
                else
                {
                    newUser = new Professor(loginName.Text, loginSurname.Text);
                }
                
                newUser.SetPassword(loginPassw.Text);
                Program.Users.Add(newUser);
                
                MessageBox.Show("Vartotojas uzregistruotas");
            }
        }
        
        
    }
}
