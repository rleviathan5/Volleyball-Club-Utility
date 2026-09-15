using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volleyball_Utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(NameInputTextBox, "Your Name");
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email emailForm = new Email();
            emailForm.Show();
        }

    }
}
