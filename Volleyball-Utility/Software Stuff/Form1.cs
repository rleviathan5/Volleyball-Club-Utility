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
        private HashSet<string> names = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(NameInputTextBox, "Your Name");
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Volleyball Utility Tool";
        }

        //event driven functions
        #region
        private void emailToolStripMenuItem_Click(object sender, EventArgs e) //TODO: change to backend email functionality, no form involved
        {
            //function return true if email sent
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
            if (e.KeyCode == Keys.Enter)
            {
                AcceptNameButton_Click(this, new EventArgs());
            }
        }

        #endregion


        //email functions
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

                return new string(File.ReadAllText(passwordFile) //remove all white space from password file
                    .Where(c => !char.IsWhiteSpace(c)).ToArray()); //linq looks hacky and is an abomination
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }

        private (string subject, string body) ConstructEmail() //pass hashset
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

        private bool SendEmail() //TODO: test shared mailbox email
        {
            string password = ReadPasswordFile();
            var senderAddress = new MailAddress("", "Abertay Volleyball Software");
            var receiverAddress1 = new MailAddress("" + "@abertay.ac.uk", "Current Secretary");
            var receieverAddress2 = new MailAddress("volleyball@abertay.ac.uk", "Shared Mailbox");
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
                foreach (var receiver in new[] { receiverAddress1, receieverAddress2 }) //sending 2 emails with same contents
                {
                    using (var email = new MailMessage(senderAddress, receiver)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(email);
                    }
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
    }
}
