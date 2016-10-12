using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfREST
{
    [ServiceContract]
    public interface IService1
    {

        //These are the Operation Contracts used to format the HTTP requests
        [OperationContract]
        [WebGet(UriTemplate = "Teams", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Team> GetTeams();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "Teams/{name}",
            ResponseFormat = WebMessageFormat.Json)]
        Team GetTeam(string name);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "Teams",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void AddTeam(String Name, String City, Stadium stadium);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            UriTemplate = "Teams",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateTeam(String Name, String City, Stadium stadium);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "Teams",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void DeleteTeams();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "Teams/{name}/Players",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Player> GetTeamPlayers(string name);


        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "Teams/{name}/Stadium",
            ResponseFormat = WebMessageFormat.Json)]
        Stadium GetTeamStadium(string name);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "Teams/{name}/Players",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void AddTeamPlayers(string name, List<Player> players);

    }


    //The data contracts, aka all the different objects
    [DataContract]
    public class Team
    {
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Stadium HomeStadium { get; set; }
        [DataMember]
        public List<Player> Players { get; set; }

    }

    [DataContract]
    public class Player
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public decimal Salary { get; set; }

    }

    [DataContract]
    public class Stadium
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public decimal TicketPrice { get; set; }
    }
}
