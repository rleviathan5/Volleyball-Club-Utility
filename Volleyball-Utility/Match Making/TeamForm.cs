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
            this.names = names;
            DisplayTeamTextBoxes();
            if (names.Count >= 6)
            {
                DisplayTeams(GenerateTeams());
            }
        }

        private List<List<string>> GenerateTeams()
        {
            int numberOfTeams = names.Count / 6;
            List<List<string>> teams = new List<List<string>>(); //3d arrays oh boy here we go

            for (int i = 0; i < numberOfTeams; i++)
            {
                teams.Add(new List<string>());
            }

            Queue<string> teamPlayers = new Queue<string>();
            Queue<string> nonTeamPlayers = new Queue<string>();

            foreach (var player in names)
            {
                if (player.Value == 1)
                {
                    teamPlayers.Enqueue(player.Key);
                }
                else if (player.Value == 2)
                {
                    nonTeamPlayers.Enqueue(player.Key);
                }
            }

            int[] teamPlayerCount = new int[numberOfTeams];

            AllocateInitialTeamPlayers(teamPlayers, teams, teamPlayerCount, numberOfTeams);
            AllocateRemainingPlayers(teamPlayers, nonTeamPlayers, teams, numberOfTeams);
            
            return teams;
        }

        private void AllocateInitialTeamPlayers(Queue<string> teamPlayers, List<List<string>> teams, int[] teamPlayerCount, int numberOfTeams)
        {
            //-------------------------------
            // ROUND ROBIN ALGORITHM
            // STAGE 1: Allocate team player
            // to a maximum of 2 per team
            //-------------------------------

            int currentTeam = 0;
            while (teamPlayers.Count > 0)
            {
                if (teamPlayerCount[currentTeam] < 2)
                {
                    teams[currentTeam].Add(teamPlayers.Dequeue());
                    teamPlayerCount[currentTeam]++;
                }

                currentTeam++;

                if (currentTeam >= numberOfTeams)
                {
                    currentTeam = 0;
                }

                //check if every team has 2 comp players
                bool allTeamsHaveTwo = true;

                for (int i = 0; i < numberOfTeams; i++)
                {
                    if (teamPlayerCount[i] < 2)
                    {
                        allTeamsHaveTwo = false;
                        break;
                    }
                }

                if (allTeamsHaveTwo)
                {
                    break;
                }
            }
        }

        private void AllocateRemainingPlayers(Queue<string> teamPlayers, Queue<string> nonTeamPlayers, List<List<string>> teams, int numberOfTeams)
        {
            //-------------------------------------
            // STAGE 2:
            // Allocate every team 6 players 
            // Use non-team players first
            // Then use team players if not enough
            //-------------------------------------

            int currentTeam = 0;
            while (nonTeamPlayers.Count > 0 || teamPlayers.Count > 0)
            {
                bool allTeamsHaveSix = true;
                for (int i = 0; i < numberOfTeams; i++)
                {
                    if (teams[i].Count < 6)
                    {
                        allTeamsHaveSix = false;

                        if(nonTeamPlayers.Count > 0)
                        {
                            teams[i].Add(nonTeamPlayers.Dequeue());
                        }
                        else if (teamPlayers.Count > 0)
                        {
                            teams[i].Add(teamPlayers.Dequeue());
                        }
                    }
                }
                if (allTeamsHaveSix)
                {
                    break;
                }
            }

            //------------------------------
            // STAGE 3:
            // All teams now have 6 players
            // Allocate remaining players
            //------------------------------

            while (teamPlayers.Count > 0 || nonTeamPlayers.Count > 0)
            {
                if (nonTeamPlayers.Count > 0)
                {
                    teams[currentTeam].Add(nonTeamPlayers.Dequeue());
                }
                else if (teamPlayers.Count > 0)
                {
                    teams[currentTeam].Add(teamPlayers.Dequeue());
                }

                currentTeam++;

                if (currentTeam >= numberOfTeams)
                {
                    currentTeam = 0;
                }
            }
        }

        private void DisplayTeams(List<List<string>> teams)
        {
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

            for (int i = 0; i < teamTextBoxes.Length; ++i)
            {
                if (i < teams.Count)
                {
                    var formattedNames = teams[i].Select(FormatNames);
                    teamTextBoxes[i].Text = string.Join(Environment.NewLine, formattedNames);
                }
            }
        }

        private string FormatNames(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;

            string[] parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string firstName = char.ToUpper(parts[0][0]) + parts[0].Substring(1).ToLower(); // ⣴⣾⣿⣿⣿⣿⣷⣦
            if (parts.Length > 1)                                                           // ⣿⣿⣿⣿⣿⣿⣿⣿
            {                                                                               // ⡟⠛⠽⣿⣿⠯⠛⢻
                char secondInitial = char.ToUpper(parts[1][0]);                             // ⣧⣀⣀⡾⢷⣀⣀⣼
                return $"{firstName} {secondInitial}.";                                     //  ⡏⢽⢴⡦⡯⢹   
            }                                                                               //  ⠙⢮⣙⣋⡵⠋ 
            return firstName;                                                               //    ⠉⠉
        }

        private void DisplayTeamTextBoxes()
        {
            int numberOfTeams = 0;
            if (names.Count >= 6)
            {
                numberOfTeams = names.Count / 6; //drops the remainder
            }

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
