using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_MEDKB
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        static void WriteToFile(string filePath, string data, bool append)
        {
            // Use StreamWriter to write data to the file
            using (StreamWriter writer = new StreamWriter(filePath, append))
            {
                // Write the data to the file
                writer.WriteLine(data);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Please input a username and password");
            }
            else
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string dataToWrite = $"{username}|{password}";
                string filePath = "account.txt";
                WriteToFile(filePath, dataToWrite, true);

                Debug.WriteLine(username + ":" + password);
                Debug.WriteLine("account written successfully");
                MessageBox.Show("Account Created Successfully", "Registration Complete");
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                string a = textBox2.Text;
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
