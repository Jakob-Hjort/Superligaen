using NLog;
using Superligaen;
using System;

public class Program
{
    private static Logger logger = LogManager.GetCurrentClassLogger();

    public static void Main()
    {
        // Opret holdene
        Team team1 = new Team("AGF");
        Team team2 = new Team("FCK");
        Team team3 = new Team("BIF");
        Team team4 = new Team("FCM");
        Team team5 = new Team("SIF");
        Team team6 = new Team("FCN");
        Team team7 = new Team("RFC");
        Team team8 = new Team("VFC");
        Team team9 = new Team("VBK");
        Team team10 = new Team("OB");
        Team team11 = new Team("Lyngby");
        Team team12 = new Team("HVFC");

        // Opret scoreboard og tilføj holdene
        Scoreboard scoreboard = new Scoreboard();
        scoreboard.AddTeam(team1);
        scoreboard.AddTeam(team2);
        scoreboard.AddTeam(team3);
        scoreboard.AddTeam(team4);
        scoreboard.AddTeam(team5);
        scoreboard.AddTeam(team6);
        scoreboard.AddTeam(team7);
        scoreboard.AddTeam(team8);
        scoreboard.AddTeam(team9);
        scoreboard.AddTeam(team10);
        scoreboard.AddTeam(team11);
        scoreboard.AddTeam(team12);

        // Opret en array af holdene
        Team[] teams = { team1, team2, team3, team4, team5, team6, team7, team8, team9, team10, team11, team12 };

        // Opret en tilfældighedsgenerator
        Random randomscore = new Random();

        // Arranger kampe, hvor hvert hold spiller to kampe mod hinanden
        for (int i = 0; i < teams.Length; i++)
        {
            for (int j = 0; j < teams.Length; j++)
            {
                if (i != j)
                {

                    //spil første kamp
                    int homeGoals = randomscore.Next(0, 5);
                    int awayGoals = randomscore.Next(0, 5);
                    logger.Info($"{teams[i].TeamName} Mod {teams[j].TeamName}");

                    Game game1 = new Game(teams[i], teams[j], homeGoals, awayGoals);
                }
            }

        }

        // Vis liga tabellen efter gruppespillet
        Console.WriteLine("\nInitial Group Stage Results:");
        List<Team> teamList = new List<Team>(teams);
        scoreboard.DisplayTable(teamList);

        // Spil slutspil og nedrykningsrunder
        scoreboard.PlayChampionshipRound(randomscore);
        scoreboard.PlayRelegationRound(randomscore);

        // Vis vinderen af slutspillet
        var champion = "Vinderen af slutspillet: " + scoreboard.Teams.OrderByDescending(t => t.Points).ThenByDescending(t => t.GoalDifference).First().TeamName;
        Console.WriteLine(champion);

        // Vis de hold, der rykker ned
        //var relegatedTeams = scoreboard.Teams.OrderByDescending(t => t.Points).ThenBy(t => t.GoalDifference).Take(2);
        var relegatedTeams = scoreboard.Teams.OrderByDescending(t => t.Points).ThenBy(t => t.GoalDifference).TakeLast(2).ToList();

        var relegated = "Holdene der rykker ned: " + string.Join(", ", relegatedTeams.Select(team => team.TeamName));
        Console.WriteLine(relegated);
    }
}
