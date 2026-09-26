using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volleyball_Utility
{
    public partial class Form1 : Form
    {
        private void TeamPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TeamPlayerCheckBox.Checked)
            {
                NotTeamPlayerCheckBox.Checked = false;
            }
        }

        private void NotTeamPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotTeamPlayerCheckBox.Checked)
            {
                TeamPlayerCheckBox.Checked = false;
            }
        }

        private int CheckForTeamPlayer()
        {
            if (TeamPlayerCheckBox.Checked)
            {
                return 1;
            }
            if (NotTeamPlayerCheckBox.Checked)
            {
                return 2;
            }
            return 0;
        }

        private void NameInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptNameButton_Click(this, new EventArgs());
            }
        }

        private void NotTeamPlayerCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptNameButton_Click(this, new EventArgs());
            }
        }

        private void TeamPlayerCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptNameButton_Click(this, new EventArgs());
            }
        }
    }
}
