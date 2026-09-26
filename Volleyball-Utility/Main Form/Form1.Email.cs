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
            string subject = "Volleyball Training " + today; // dd/mm/yyyy time
            string body = "";

            foreach (var item in names)
            {
                body = string.Concat(body, item.Key + "\n"); //concatenating every name present at training
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
                return true; //return true if email sends
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false; //return false if email fails
            }
        }
    }
}
