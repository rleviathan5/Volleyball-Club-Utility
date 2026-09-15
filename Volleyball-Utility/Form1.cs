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
        HashSet<string> names = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(NameInputTextBox, "Your Name");
            this.MaximizeBox = false; //remove maximze button
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // prevent window resizing
            this.Text = "Volleyball Utility Tool";
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email emailForm = new Email();
            emailForm.Show();
        }

        private void AcceptNameButton_Click(object sender, EventArgs e)
        {
            if (!names.Add(NameInputTextBox.Text))
            {
                MessageBox.Show(
                    "This name has already been entered. Try adding the first letter of your surname - 'Niall M'",
                    "Duplicate Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            MessageBox.Show("Thanks for coming", 
                "Success!",
                MessageBoxButtons.OK
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string name in names)
            {
                MessageBox.Show(name);
            }
        }
    }
}
