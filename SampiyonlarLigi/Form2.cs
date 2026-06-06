using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampiyonlarLigi
{
    public partial class Form2 : Form
    {
        private List<Team> teams;

        string connectionString = "Data Source=LAPTOP-JGP1CT66;Initial Catalog=CLDraw;Integrated Security=True;TrustServerCertificate=True";

        public Form2(List<Team> teamList)
        {
            InitializeComponent();
            teams = teamList;

            dataGridViewTeams.DataSource = null;
            dataGridViewTeams.DataSource = teams;

            dataGridViewTeams.AllowUserToAddRows = true;
            dataGridViewTeams.AllowUserToDeleteRows = true;
            dataGridViewTeams.ReadOnly = false;
            dataGridViewTeams.AutoGenerateColumns = true;

        }

        private void RefreshGrid()
        {
            dataGridViewTeams.DataSource = null;
            dataGridViewTeams.DataSource = teams;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtTeamName.Text.Trim();
            string country = txtTeamCountry.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(country))
            {
                MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Teams (TeamName, TeamCountry) VALUES (@name, @country)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.ExecuteNonQuery();
                }
            }

            teams.Add(new Team(name, country));
            dataGridViewTeams.DataSource = null;
            dataGridViewTeams.DataSource = teams;

            txtTeamName.Clear();
            txtTeamCountry.Clear();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeams.CurrentRow != null)
            {
                var row = dataGridViewTeams.CurrentRow;
                string name = row.Cells[0].Value?.ToString();
                string country = row.Cells[1].Value?.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(country))
                {
                    Team teamToRemove = teams.FirstOrDefault(t => t.TeamName == name && t.TeamCountry == country);
                    if (teamToRemove != null)
                        teams.Remove(teamToRemove);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Teams WHERE TeamName = @Name AND TeamCountry = @Country", conn);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Country", country);
                        cmd.ExecuteNonQuery();
                    }

                    RefreshGrid();
                    MessageBox.Show("Team has been deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
