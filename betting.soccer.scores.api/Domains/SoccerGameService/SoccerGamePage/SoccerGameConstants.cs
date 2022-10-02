using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public class SoccerGameConstants
    {
        public const string Requester = "RU";
        public const string Administrator = "AU";
        public const string Registration = "Registration_successful";
        public const string SoccerGameNotFound = "Soccer game not found";
        public const string GameDelete = "Soccer game deleted successfully";
        public const string GameUpdate = "Soccer game updated successfully";
        public const string GameThatDay = "The  {0} team has a game that day";
        public const string ProgrammingHappened = "This game schedule has already happened, the matches between {} and {} on date {} have already happened";
        public const string CurrentDateNotMatch = "the selected match date is not the current day";
    }
}
