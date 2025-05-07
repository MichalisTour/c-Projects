namespace CafeApp
{
    public partial class LoginForm : Form
    {
        public string usernameText1 = string.Empty;
        public string passwordText1 = string.Empty;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void UsernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            this.usernameText1 = usernameText.Text;
            this.passwordText1 = passwordText.Text;
            User user1 = new User();
            if (user1.CheckCredentials(this.usernameText1, this.passwordText1))
            {
                MessageBox.Show($"Login {user1.Name.ToUpper()}");
                this.Hide();
                new OrderForm().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("wrong credentials invalid username or password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
