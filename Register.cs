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

        private void button1_Click(object sender, EventArgs e)
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
        static void WriteToFile(string filePath, string data, bool append)
        {
            // Use StreamWriter to write data to the file
            using (StreamWriter writer = new StreamWriter(filePath, append))
            {
                // Write the data to the file
                writer.WriteLine(data);
            }
        }
    }
}
