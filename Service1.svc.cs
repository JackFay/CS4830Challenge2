using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        //In memory data structure to hold all of the teams
        static List<Team> teams = new List<Team>();


        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public Team GetTeam(string name)
        {
            //Checking to see if team exists
            Team t = teams.Find(x => x.Name == name);
            if (t == null) return null;
            return t;
        }

        public void AddTeam(string Name, string City, Stadium stadium)
        {
            if (teams.Find(x => x.Name == Name) != null) return;
            //creating the new team and setting attributes
            Team team = new Team();
            team.Name = Name;
            team.City = City;
            team.HomeStadium = stadium;
            team.Players = new List<Player>();

            teams.Add(team);
        }

        public void UpdateTeam(string Name, string City, Stadium stadium)
        {
            //Checking to see if team exists
            Team t = teams.Find(x => x.Name == Name);
            if (t == null) return;
            t.City = City;
            t.HomeStadium = stadium;
        }

        public void DeleteTeams()
        {
            teams.Clear();
        }

        public IEnumerable<Player> GetTeamPlayers(string name)
        {
            //Checking to see if team exists
            Team t = teams.Find(x => x.Name == name);
            if (t == null) return null;

            return t.Players;
        }

        public Stadium GetTeamStadium(string name)
        {
            //Checking to see if team exists
            Team t = teams.Find(x => x.Name == name);
            if (t == null) return null;

            return t.HomeStadium;
        }

        public void AddTeamPlayers(string name, List<Player> players)
        {
            //Checking to see if team exists
            Team t = teams.Find(x => x.Name == name);
            if (t == null) return;
            foreach (var p in players)
            {
                t.Players.Add(p);
            }



        }
    }
}
