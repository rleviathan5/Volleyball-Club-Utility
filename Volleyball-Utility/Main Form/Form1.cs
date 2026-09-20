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
using Volleyball_Utility.Match_Making;

namespace Volleyball_Utility
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> names = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(NameInputTextBox, "Your First Name");
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Volleyball Utility Tool";
        }


        //event driven functions
        #region
        private void emailToolStripMenuItem_Click(object sender, EventArgs e) //TODO: change to backend email functionality, no form involved
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
                }
            }
        }

        private void AcceptNameButton_Click(object sender, EventArgs e)
        {
            int playerID = CheckForTeamPlayer();
            string name = NameInputTextBox.Text.Trim();
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

        private void courtScrambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var matchForm = new MatchMaking(names);
            matchForm.Show();
        }
        #endregion


        //email functions
        #region
        private (string gmail, string password, string studentNo) ReadPasswordFile()
        {
            string gmail = "";
            string password = "";
            string studentNo = "";
            try
            {
                string[] lines = File.ReadAllLines("info.txt");
                gmail = lines[0].Trim();
                password = lines[1].Trim();
                studentNo = lines[2].Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return (gmail, password, studentNo);
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

        private bool SendEmail()
        {
            var (gmail, password, studentNo) = ReadPasswordFile();
            var senderAddress = new MailAddress(gmail, "Abertay Volleyball Software");
            var receiverAddress1 = new MailAddress(studentNo + "@abertay.ac.uk", "Secretary");
            var receieverAddress2 = new MailAddress("volleyball@abertay.ac.uk", "Abertay");
            var (subject, body) = ConstructEmail();

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderAddress.Address, password),
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

        private void TeamPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NotTeamPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private int CheckForTeamPlayer()
        {
            if (TeamPlayerCheckBox.Checked)
            {
                return 1;
            }
            else return 2;
        }
    }
}
