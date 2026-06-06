using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampiyonlarLigi
{
    public class Team
    {
        private string teamName;
        private string teamCountry;

        public Team(string name, string country)
        {
            teamName = name;
            teamCountry = country;
        }

        public string TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public string TeamCountry
        {
            get { return teamCountry; }
            set { teamCountry = value; }
        }
        public override string ToString()
        {
            return teamName + " - " + teamCountry;
        }
    }
}
