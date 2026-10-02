using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Volleyball_Utility
{
    public partial class SetupForm : Form
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        public SetupForm()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(GmailTextBox, "Your personal gmail");
            WinAPI.SetPlaceholderText(SecretaryNoTextBox, "Secretary student number");
            WinAPI.SetPlaceholderText(SharedAppPwdTextBox, "Shared app password");
        }

        private void CreateSetupFile()
        {
            try
            {
                File.WriteAllLines("info.txt", new[]
                {
                    GmailTextBox.Text,
                    SharedAppPwdTextBox.Text,
                    SecretaryNoTextBox.Text
                });
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void VerifyUserEmailButton_Click(object sender, EventArgs e)
        {
            if (!VerifyInputData()) return; //if a check fails and a false bool is received, break the function
           
            DialogResult message = MessageBox.Show(
                "Are you sure you want to finalise this data?",
                "Caution!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );

            if (message == DialogResult.OK)
            {
                CreateSetupFile();
                this.DialogResult = DialogResult.OK; //allowing main form to launch
                return;
            }
        }

        private bool VerifyInputData() //TODO: add shard app pwd verification
        {
            string gmailRegex = @"^[a-z0-9]+(?!.*(?:\+{2,}|-{2,}|\.{2,}))(?:[.+-]?[a-z0-9])*@gmail\.com$";
            string studentNumberRegex = @"^[1-9][0-9]{6}$";

            if (string.IsNullOrEmpty(GmailTextBox.Text) || string.IsNullOrEmpty(SecretaryNoTextBox.Text) || string.IsNullOrEmpty(SharedAppPwdTextBox.Text))
            {
                MessageBox.Show("Please fill out all information fields", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(GmailTextBox.Text, gmailRegex, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Please enter a valid gmail address", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((!Regex.IsMatch(SecretaryNoTextBox.Text, studentNumberRegex, RegexOptions.IgnoreCase)))
            {
                MessageBox.Show("Please enter a valid abertay student number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            foreach (Control ctrl in this.Controls)
            {
                controlBounds[ctrl] = ctrl.Bounds;
                originalFontSizes[ctrl] = ctrl.Font.Size;
            }
        }

        private void SetupForm_Resize(object sender, EventArgs e)
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
