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
        private HashSet<string> names = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(NameInputTextBox, "Your Name");
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Volleyball Utility Tool";
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e) //TODO: change to backend email functionality, no form involved
        {
            //Setup emailForm = new Setup(names);
            //emailForm.Show();
        }

        private void AcceptNameButton_Click(object sender, EventArgs e)
        {
            if (!names.Add(NameInputTextBox.Text.Trim())) //displays error if a duplicate name is entered
            {
                MessageBox.Show(
                    "This name has already been entered. \nTry adding the first letter of your surname - 'Niall M'",
                    "Duplicate Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            NameInputTextBox.Clear();
            MessageBox.Show("Thanks for coming", 
                "Success!",
                MessageBoxButtons.OK
                );
        }

        private void NameInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                AcceptNameButton_Click(this, new EventArgs());
            }
        }
    }
}
