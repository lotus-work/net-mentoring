using System;
using System.Windows.Forms;
using Task_2_ClassLibrary;
namespace Task_1_2_Winform
{
    public partial class FormOutputPrompt : Form
    {
        private string _username;
        public FormOutputPrompt(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void FormOutputPrompt_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_username))
            {
                _username = "Mr.Hello World";
            }

            labelOutput.Text = $"Hello, {_username}!";
            var messageFromClassLibrary = ConcatenationLogic.WelcomeUser(_username);
            labelFromClassLibrary.Text = $"Output from class library: {messageFromClassLibrary}";
        }
    }
}
