using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void WriteToLocalBackup(string name, int playerID)
        {
            try
            {
                File.AppendAllText("temp.txt", $"{name},{playerID}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadLocalBackup()
        {
            if (!File.Exists("temp.txt")) return;
            try
            {
                string[] lines = File.ReadAllLines("temp.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    int playerID = int.Parse(parts[1]);
                    if (!names.ContainsKey(parts[0])) //ignore duplicates
                    {
                        names.Add(parts[0], playerID);
                    }
                }
            }
            catch
            {
                MessageBox.Show(
                    "Something went wrong. Try deleting the 'temp.txt' file",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}
