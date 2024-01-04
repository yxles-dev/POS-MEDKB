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

        static int tries = 0;
        private bool inCooldown = false;


        private async void button1_Click(object sender, EventArgs e)
        {
            // Insert textBox values to variables for checking
            string targetUsername = textBox1.Text;
            string targetPassword = textBox2.Text;

            if (inCooldown)
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Please wait for the remaining time before logging in.");
                return;
            }

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Input a credential");
            }
            else if (tries >= 3)
            {
                System.Media.SystemSounds.Asterisk.Play();
                Debug.WriteLine("Executed");
                inCooldown = true;
                this.Enabled = false;
                MessageBox.Show("You have exceeded the maximum number of tries. Please wait for 30 seconds before trying again.");
                await Task.Delay(30000);
                inCooldown = false;
                this.Enabled = true;
                tries = 0;
            }
            else
            {
                Debug.WriteLine(tries);
                // Locate the file where accounts are stored (this is highly unsecured lmao)
                string filePath = "account.txt";
                bool matchFound = false;

                // Show alert if account.txt doesnt exist in the folder instead of crashing
                try
                {
                    matchFound = CheckCredentials(filePath, targetUsername, targetPassword);

                    if (matchFound)
                    {
                        MessageBox.Show("Account Login Successful", "Login Successful");
                        launchMenu();
                    }
                    else
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        MessageBox.Show("Wrong Account Credential", "Login Error");
                    }

                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    Debug.WriteLine("Triggered System.IO.FileNotFoundException");
                    MessageBox.Show("Wrong Account Credential", "Login Error");
                }
                tries++;
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

            // (Deniel) use ShowDialog instead of Show() to be able to
            // make this form a parent
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Hide this form/control and launch the Register Screen
            this.Hide();
            Register register = new Register();

            // (Deniel) use ShowDialog instead of Show() to be able to
            // make this form a parent
            register.ShowDialog(this);
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
