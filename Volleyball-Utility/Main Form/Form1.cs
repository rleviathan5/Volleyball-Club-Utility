using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volleyball_Utility
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> names = new Dictionary<string, int>();
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        public Form1()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(NameInputTextBox, "Your First Name");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Volleyball Utility Tool";
            LoadLocalBackup();
        }

        private void courtScrambleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var teamForm = new TeamForm(names);
            teamForm.Show();
        }

        private void AcceptNameButton_Click(object sender, EventArgs e)
        {
            int playerID = CheckForTeamPlayer();
            string name = NameInputTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(
                    "Please enter your name",
                    "Missing Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            if (playerID == 0) //if no textbox ticked
            {
                MessageBox.Show(
                    "Please specify whether you are/aren't on the team",
                    "Missing Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            if (names.ContainsKey(name)) //displays error if a duplicate name is entered
            {
                MessageBox.Show(
                    "This name has already been entered. \nTry adding the first letter of your surname - 'Niall M'",
                    "Duplicate Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            
            names.Add(name, playerID);
            WriteToLocalBackup(name, playerID); //this code is SPECIFICALLY because our president butchered the software one time
            NameInputTextBox.Clear();
            TeamPlayerCheckBox.Checked = false;
            NotTeamPlayerCheckBox.Checked = false;

            MessageBox.Show("Thanks for coming",
                "Success!",
                MessageBoxButtons.OK
                );
        }

        private void emailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to commit this session data?",
                "Warning!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (SendEmail())
                {
                    MessageBox.Show("Email successfully sent to secretary", "Success!");

                    if(File.Exists("temp.txt"))
                    {
                        File.Delete("temp.txt");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            foreach (Control ctrl in this.Controls)
            {
                controlBounds[ctrl] = ctrl.Bounds;
                originalFontSizes[ctrl] = ctrl.Font.Size;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;
            float fontRatio = Math.Max(xRatio, yRatio);

            foreach (Control ctrl in this.Controls)
            {
                Rectangle original = controlBounds[ctrl];
                ctrl.SetBounds(
                    (int)(original.X * xRatio),
                    (int)(original.Y * yRatio),
                    (int)(original.Width * xRatio),
                    (int)(original.Height * yRatio)
                    );

                float originalFontSize = originalFontSizes[ctrl];

                ctrl.Font = new Font(ctrl.Font.FontFamily, originalFontSize * fontRatio, ctrl.Font.Style);
            }
            titleLabel.Left = (this.ClientSize.Width - titleLabel.Width) / 2;
        }
    }
}
