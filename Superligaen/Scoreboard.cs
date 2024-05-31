using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superligaen
{
    public class Scoreboard
    {
        // Liste over hold i ligaen.
        private List<Team> teams;

        // Konstruktor til initialisering af en ny Scoreboard objekt.
        public Scoreboard()
        {
            teams = new List<Team>(); // Initialiserer den interne liste over hold.
        }

        // Metode til at tilføje et hold til ligaen.
        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        // Metode til at vise liga tabellen.
        public void DisplayTable()
        {
            // Sorterer holdene efter point, mål forskel og navn.
            var sortedTeams = teams.OrderByDescending(t => t.Points)
                                   .ThenByDescending(t => t.goalDifference)
                                   .ToList();

            // Udskriver tabellen med holdenes statistikker.
            Console.WriteLine($"{"Team",-10}\t{"Kampe",6}\t{"Vundet",6}\t{"Uafgjort",10}\t{"Tabt",6}\t{"Mål scoret",6}\t{"MÅL GÅET IND",6}\t{"MÅL DIFFERENCE",6}\t{"POINTS",6}");
            foreach (var team in sortedTeams)
            {
                Console.WriteLine($"{team.TeamName,-10}\t{team.matchesPlayed,6}\t{team.matchesWon,6}\t{team.matchesEven,10}\t{team.matchesLost,6}\t{team.goalScored,10}\t{team.goalAgainst,12}\t{team.goalDifference,14}\t{team.Points,6}");
            }
        }


    }
}
