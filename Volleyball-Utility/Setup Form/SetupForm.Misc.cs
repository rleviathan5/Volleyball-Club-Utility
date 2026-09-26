using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volleyball_Utility
{
    public partial class SetupForm : Form
    {
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

        private void SharedAppPwdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyUserEmailButton_Click(this, new EventArgs());
            }
        }
    }
}
