using NLog;
using Superligaen;
using System;
using System.Collections.Generic;
using System.Linq;

public class Scoreboard
{
    private static Logger logger = LogManager.GetCurrentClassLogger(); // Deklaration af logger-objektet

    // Liste over hold i ligaen.
    private List<Team> teams;

    public List<Team> Teams
    {
        get { return teams; }
    }

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
    public void DisplayTable(List<Team> teams)
    {
        // Sorterer holdene efter point, mål forskel og navn.
        var sortedTeams = teams.OrderByDescending(t => t.Points)
                               .ThenByDescending(t => t.goalDifference)
                               .ToList();

        // Udskriver tabellen med holdenes statistikker.
        Console.WriteLine($"{"Team",-10}\t{"Kampe",6}\t{"Vundet",6}\t{"Uafgjort",10}\t{"Tabt",6}\t{"Mål scoret",10}\t{"Mål gået ind",12}\t{"Mål difference",14}\t{"Points",6}");
        foreach (var team in sortedTeams)
        {
            Console.WriteLine($"{team.TeamName,-10}\t{team.matchesPlayed,6}\t{team.matchesWon,6}\t{team.matchesEven,10}\t{team.matchesLost,6}\t{team.goalScored,10}\t{team.goalAgainst,12}\t{team.goalDifference,14}\t{team.Points,6}");
        }
    }

    // Metode til at spille en slutspilrunde med de øverste 6 hold.
    public void PlayChampionshipRound(Random random)
    {
        var topTeams = teams.OrderByDescending(t => t.Points)
                            .ThenByDescending(t => t.goalDifference)
                            .Take(6)
                            .ToList();

        PlayRound(topTeams, "Championship Round", random);

        // Log vinderen af slutspillet
        var winner = topTeams.First();
        logger.Info($"Vinderen af slutspillet: {winner.TeamName}");
    }

    // Metode til at spille en nedrykningsrunde med de nederste 6 hold.
    public void PlayRelegationRound(Random random)
    {
        var bottomTeams = teams.OrderByDescending(t => t.Points)
                               .ThenByDescending(t => t.goalDifference)
                               .Skip(6)
                               .Take(6)
                               .ToList();

        PlayRound(bottomTeams, "Relegation Round", random);

        // Log de to hold, der rykker ned
        var relegatedTeams = bottomTeams.TakeLast(2);
        foreach (var team in relegatedTeams)
        {
            logger.Info($"Holdet der rykker ned: {team.TeamName}");
        }
    }

    // Privat metode til at afvikle en runde af kampe.
    private void PlayRound(List<Team> teams, string roundName, Random random)
    {
        Console.WriteLine($"\n{roundName}");

        for (int i = 0; i < teams.Count; i++)
        {
            for (int j = i + 1; j < teams.Count; j++)
            {
                int homeGoals = random.Next(0, 5);
                int awayGoals = random.Next(0, 5);
                new Game(teams[i], teams[j], homeGoals, awayGoals);

                homeGoals = random.Next(0, 5);
                awayGoals = random.Next(0, 5);
                new Game(teams[j], teams[i], homeGoals, awayGoals);
            }
        }

        // Vis tabellen kun for de hold, der er i den aktuelle runde
        DisplayTable(teams);
    }
}

