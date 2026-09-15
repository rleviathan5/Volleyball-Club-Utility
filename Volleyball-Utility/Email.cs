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
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
            WinAPI.SetPlaceholderText(SenderEmailTextBox, "Email");
            WinAPI.SetPlaceholderText(SenderPasswordTextBox, "Password");
        }

        private void Email_Load(object sender, EventArgs e)
        {
            
        }
    }
}
