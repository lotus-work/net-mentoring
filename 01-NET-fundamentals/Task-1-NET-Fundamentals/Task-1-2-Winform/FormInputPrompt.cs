using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Task_1_2_Winform
{
    public partial class FormInputPrompt : Form
    {
        public string username;
        public FormInputPrompt()
        {
            InitializeComponent();
        }

        private void userPrompt_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            username = textBoxName.Text;
            var outputPromptForm = new FormOutputPrompt(username);
            outputPromptForm.Show();
        }

        private void FormInputPrompt_Load(object sender, EventArgs e)
        {

        }
    }
}
