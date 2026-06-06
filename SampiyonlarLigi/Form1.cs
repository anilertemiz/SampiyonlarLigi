using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SampiyonlarLigi
{
    public partial class Form1 : Form
    {
        List<Team> teams;

        List<ListBox> pots = new List<ListBox>();
        List<ListBox> groups = new List<ListBox>();

        string connectionString = "Data Source=LAPTOP-JGP1CT66;Initial Catalog=CLDraw;Integrated Security=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnPot.Visible = true;
            btnGroups.Visible = false;
            btnRefresh.Visible = false;

            teams = new List<Team>();

            LoadTeamsFromDatabase();
        }

        private async void btnPot_Click(object sender, EventArgs e)
        {
            await Task.Delay(500);

            btnPot.Visible = false;
            btnGroups.Visible = true;

            await Task.Delay(500);

            if (LstPot1.Items.Count == 8 &&
                LstPot2.Items.Count == 8 &&
                LstPot3.Items.Count == 8 &&
                LstPot4.Items.Count == 8)

            {
                MessageBox.Show("The pots are already full. Please click 'Refresh' button for new draw.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LstPot1.Items.Clear();
            LstPot2.Items.Clear();
            LstPot3.Items.Clear();
            LstPot4.Items.Clear();

            Random rdm = new Random();
            List<int> chosenTeams = new List<int>();
            for (int i = 0; i < teams.Count; i++)
            {
                int chosenTeam = rdm.Next(0, teams.Count);
                if (chosenTeams.Contains(chosenTeam))
                {
                    i--;
                }
                else
                {
                    chosenTeams.Add(chosenTeam);
                }
            }
            for (int i = 0; i < chosenTeams.Count; i++)
            {
                if (i < 8)
                {
                    LstPot1.Items.Add(teams[chosenTeams[i]]);
                }
                else if (i < 16)
                {
                    LstPot2.Items.Add(teams[chosenTeams[i]]);
                }
                else if (i < 24)
                {
                    LstPot3.Items.Add(teams[chosenTeams[i]]);
                }
                else
                {
                    LstPot4.Items.Add(teams[chosenTeams[i]]);
                }
            }
            pots.Add(LstPot1);
            pots.Add(LstPot2);
            pots.Add(LstPot3);
            pots.Add(LstPot4);

            groups.Add(listBox1);
            groups.Add(listBox2);
            groups.Add(listBox3);
            groups.Add(listBox4);
            groups.Add(listBox5);
            groups.Add(listBox6);
            groups.Add(listBox7);
            groups.Add(listBox8);
        }

        private async void btnGroup_Click(object sender, EventArgs e)
        {
            await Task.Delay(500);

            btnGroups.Visible = false;
            btnRefresh.Visible = true;

            bool theGroupsFull = groups.All(g => g.Items.Count == 4);
            if (theGroupsFull)
            {
                MessageBox.Show("The groups are already full. Please click 'Refresh' button for new draw.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var group in groups)
                group.Items.Clear();

            Random rdm = new Random();

            for (int potIndex = 0; potIndex < 4; potIndex++)
            {
                List<Team> potTeams = pots[potIndex].Items.Cast<Team>().ToList();

                foreach (Team team in potTeams)
                {
                    List<ListBox> availableGroups = groups
                        .Where(g => g.Items.Count < 4 && !AreThereAnyTeamsWithSameCountry(g, team))
                        .ToList();

                    if (availableGroups.Count == 0)
                    {
                        MessageBox.Show($"Team {team.TeamName} from {team.TeamCountry} could not be placed into a valid group.\nPlease click Refresh and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int groupIndex = rdm.Next(availableGroups.Count);
                    availableGroups[groupIndex].Items.Add(team);

                    await Task.Delay(100);
                }
            }
            MessageBox.Show("Groups have been successfully drawn!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool AreThereAnyTeamsWithSameCountry(ListBox group, Team team)
        {
            foreach (Team t in group.Items)
            {
                if (t.TeamCountry == team.TeamCountry)
                    return true;
            }
            return false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LstPot1.Items.Clear();
            LstPot2.Items.Clear();
            LstPot3.Items.Clear();
            LstPot4.Items.Clear();

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            pots.Clear();
            groups.Clear();

            btnRefresh.Visible = false;
            btnPot.Visible = true;
        }

        private void btnTeamManager_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(teams);
            frm.ShowDialog();
        }

        private void LoadTeamsFromDatabase()
        {
            teams = new List<Team>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TeamName, TeamCountry FROM Teams", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["TeamName"].ToString();
                    string country = reader["TeamCountry"].ToString();
                    teams.Add(new Team(name, country));
                }
            }
        }
    }
}
