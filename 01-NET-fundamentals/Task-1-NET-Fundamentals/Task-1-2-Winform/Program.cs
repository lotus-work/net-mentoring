using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_2_Winform
{
    static class Program
    {
        public static FormInputPrompt formInputPrompt;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            formInputPrompt = new FormInputPrompt();
            Application.Run(new FormInputPrompt());
        }
    }
}
