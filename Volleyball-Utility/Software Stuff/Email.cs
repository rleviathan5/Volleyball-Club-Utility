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
    public partial class Email : Form
    {
        private HashSet<string> names;

        public Email(HashSet<string> names)
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(SenderEmailTextBox, "Your personal gmail");
            WinAPI.SetPlaceholderText(ReceiverStuNoTextBox, "Secretary student number");
            this.names = names; //set current scope hashset equal to hashset declared in form1
            this.MaximizeBox = false;
        }

        //email construction functions
        #region
        private string ReadPasswordFile()
        {
            try
            {
                // backstep 2 levels in the repo
                // Volleyball-Utility\bin\Release -> Volleyball-Utility
                string repoPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../"));

                // access Volleyball-Utility/YourGmailPasswordHere
                string passwordFile = Path.Combine(repoPath, "YourGmailPasswordHere.txt");

                return new string (File.ReadAllText(passwordFile) //remove all white space from password file
                    .Where(c => !char.IsWhiteSpace(c)).ToArray()); //linq looks hacky and is an abomination
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }

        private (string subject, string body) ConstructEmail()
        {
            DateTime today = DateTime.Now;
            string subject = "Volleyball Training " + today; // volleyball training dd/mm/yyyy time
            string body = "";

            foreach (string name in names)
            {
                body = string.Concat(body, name + "\n"); //concatenating every name present at training
            }
            body = string.Concat(body, "Number of volleyballers present: ", names.Count);
            return (subject, body);
        }

        private bool SendEmail() //TODO: add redundant email to university club email too
        {
            string password = ReadPasswordFile();
            var senderAddress = new MailAddress(SenderEmailTextBox.Text, "Abertay Volleyball Software");
            var receiverAddress = new MailAddress(ReceiverStuNoTextBox.Text + "@abertay.ac.uk", "To the current secretary");
            string senderPassword = password;

            var emailContent = ConstructEmail();
            string subject = emailContent.subject;
            string body = emailContent.body;

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderAddress.Address, senderPassword),
                    Timeout = 20000
                };
                using (var email = new MailMessage(senderAddress, receiverAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(email);
                }
                return true; //return ok if email sends
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false; //return cancel if email fails
            }
        }
        #endregion

        private bool VerifyInputData()
        {
            string gmailRegex = @"^[a-z0-9]+(?!.*(?:\+{2,}|-{2,}|\.{2,}))(?:[.+-]?[a-z0-9])*@gmail\.com$";
            string studentNumberRegex = @"^[1-9][0-9]{6}$";

            if (string.IsNullOrEmpty(SenderEmailTextBox.Text) || string.IsNullOrEmpty(ReceiverStuNoTextBox.Text))
            {
                MessageBox.Show("Please fill out all information fields", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(SenderEmailTextBox.Text, gmailRegex, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Please enter a valid gmail address", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((!Regex.IsMatch(ReceiverStuNoTextBox.Text, studentNumberRegex, RegexOptions.IgnoreCase)))
            {
                MessageBox.Show("Please enter a valid abertay student number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void VerifyUserEmailButton_Click(object sender, EventArgs e)
        {
            if (!VerifyInputData()) return; //if a check fails and a false bool is received, break the function
           
            DialogResult message = MessageBox.Show(
                "Are you sure you want to commit this attendance data?",
                "Caution!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );

            if (message == DialogResult.OK)
            {
                if (SendEmail())
                {
                    MessageBox.Show("Successfully sent email to secretary", "Success!");
                }
                else return;
            }
        }

        private void SenderEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyUserEmailButton_Click(this, new EventArgs());
            }
        }

        private void ReceiverStuNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyUserEmailButton_Click(this, new EventArgs());
            }
        }
    }
}
