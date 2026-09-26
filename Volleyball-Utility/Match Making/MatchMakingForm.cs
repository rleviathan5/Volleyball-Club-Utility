using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volleyball_Utility.Match_Making
{
    public partial class MatchMakingForm : Form
    {
        private Dictionary<string, int> names; 
        public MatchMakingForm(Dictionary<string, int> names)
        {
            InitializeComponent();
            Team1TextBox.Lines = new string[] {""};
            this.names = names;
        }
    }
}
