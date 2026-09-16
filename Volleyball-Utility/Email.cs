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

namespace Volleyball_Utility
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(SenderEmailTextBox, "Your personal gmail");
            WinAPI.SetPlaceholderText(ReceiverStuNoTextBox, "Secretary student number");
        }

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

        private DialogResult SendEmail()
        {
            string password = ReadPasswordFile();
            var senderAddress = new MailAddress(SenderEmailTextBox.Text, "Abertay Volleyball Software");
            var receiverAddress = new MailAddress(ReceiverStuNoTextBox.Text + "@abertay.ac.uk", "To me");
            string senderPassword = password;
            const string subject = "testing from software";
            const string body = "reply to me if this works pls";

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
                return DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return DialogResult.Cancel;
            }
        }

        private void VerifyUserEmailButton_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show(
                "Are you sure you want to commit this attendance data?",
                "Caution!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );

            if (message == DialogResult.OK) //TODO
            {
                if (SendEmail() == DialogResult.OK)
                {
                    MessageBox.Show("Successfully sent email to secretary", "Success!");
                }
                else
                {
                    return;
                }
            }
        }
    }
}
