using System.Diagnostics;
using System.IO;

namespace POS_MEDKB
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int tries = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            // Insert textBox values to variables for checking
            string targetUsername = textBox1.Text;
            string targetPassword = textBox2.Text;

            tries++;

            if (tries == 4)
            {
                MessageBox.Show("Try again later");
            } else if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Input a credential");
            } else
            {
                // Locate the file where accounts are stored (this is highly unsecured lmao)
                string filePath = "account.txt";

                // use CheckCredentials function to check if an account was on the file
                bool matchFound = CheckCredentials(filePath, targetUsername, targetPassword);

                if (matchFound)
                {
                    MessageBox.Show("Account Login Successful", "Login Successful");
                    launchMenu();
                }
                else
                {
                    MessageBox.Show("Wrong Account Credential", "Login Error");
                }
            }
        }
        static bool CheckCredentials(string filePath, string targetUsername, string targetPassword)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length == 2 && parts[0] == targetUsername && parts[1] == targetPassword)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        private void launchMenu()
        {
            // Hide this form/control and launch the MainScreen
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Hide this form/control and launch the Register Screen
            this.Hide();
            Register register = new Register();
            register.ShowDialog(this);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
