using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superligaen
{
    public class Game
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get;set; }

        // Konstruktor til initialisering af et nyt Game objekt med hold og mål.
        public Game(Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
            UpdateTeamStats();
        }

        // Privat metode til at opdatere holdenes statistikker efter en kamp.
        private void UpdateTeamStats()
        {
            HomeTeam.matchesPlayed++;
            AwayTeam.matchesPlayed++;
            HomeTeam.goalScored += HomeGoals;
            HomeTeam.goalAgainst += AwayGoals;
            AwayTeam.goalScored += AwayGoals;
            AwayTeam.goalAgainst += HomeGoals;
            HomeTeam.goalDifference = HomeTeam.goalScored - HomeTeam.goalAgainst;
            AwayTeam.goalDifference = AwayTeam.goalScored - AwayTeam.goalAgainst;

            if(HomeGoals > AwayGoals ) 
            {
                HomeTeam.matchesWon++;
                HomeTeam.Points += 3;
                AwayTeam.matchesLost++;
            }
            else if(HomeGoals < AwayGoals )
            {
                AwayTeam.matchesWon++;
                AwayTeam.Points += 3;
                HomeTeam.matchesLost++;
            }
            else
            {
                HomeTeam.matchesEven++;
                AwayTeam.matchesEven++;
                HomeTeam.Points++;
                AwayTeam.Points++;
            }
        }



    }
}
