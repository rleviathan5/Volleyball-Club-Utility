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
    public partial class MatchOrderForm : Form
    {
        private Dictionary<string, int> names;
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        public MatchOrderForm(Dictionary<string, int> names)
        {
            InitializeComponent();
            this.names = names;
        }

        private void GenerateMatchOrder()
        {

        }

        private void MatchOrderForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            foreach (Control ctrl in this.Controls)
            {
                controlBounds[ctrl] = ctrl.Bounds;
                originalFontSizes[ctrl] = ctrl.Font.Size;
            }
        }

        private void MatchOrderForm_Resize(object sender, EventArgs e)
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
