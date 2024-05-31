using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superligaen
{
    public class Team
    {

        public string TeamName { get; set; }

        public int matchesPlayed { get; set; } = 0;

        public int matchesWon { get; set; } = 0;

        public int matchesEven { get; set; } = 0;

        public int matchesLost { get; set; } = 0;
        
        public int goalDifference { get; set; } = 0;

        public int goalScored { get; set; } = 0;

        public int goalAgainst { get; set; } = 0;

        public int Points { get; set; } = 0;

        // Konstruktor til initialisering af et nyt Team objekt med et navn.
        public Team(string teamName)
        {
            TeamName = teamName;

        }


    }
}
