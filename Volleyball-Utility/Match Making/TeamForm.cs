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
    public partial class TeamForm : Form
    {
        private Dictionary<string, int> names;
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        public TeamForm(Dictionary<string, int> names)
        {
            InitializeComponent();
            Team1TextBox.Lines = new string[] {""};
            this.names = names;
            DisplayTeamTextBoxes();
        }

        private void DisplayTeamTextBoxes()
        {
            int numberOfTeams = names.Count / 6; //drops the remainder
            TextBox[] teamTextBoxes =
            {
                Team1TextBox,
                Team2TextBox,
                Team3TextBox,
                Team4TextBox,
                Team5TextBox,
                Team6TextBox,
                Team7TextBox,
            };
            Label[] teamLabels =
            {
                Team1Label,
                Team2Label,
                Team3Label,
                Team4Label,
                Team5Label,
                Team6Label,
                Team7Label,
            };

            for (int i = 0; i < teamTextBoxes.Length; ++i)
            {
                teamTextBoxes[i].Visible = (i < numberOfTeams); //i < numberOfTeams evaluates to true/false - cool!
                teamLabels[i].Visible = (i < numberOfTeams);
            }
        }

        private void TeamForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            foreach (Control ctrl in this.Controls)
            {
                controlBounds[ctrl] = ctrl.Bounds;
                originalFontSizes[ctrl] = ctrl.Font.Size;
            }
        }

        private void TeamForm_Resize(object sender, EventArgs e)
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
