using System.Text.Json.Serialization;
using Transenvios.Shipping.Api.Domains;

namespace bettingsoccerscoresapi.Domains.UserService.UserPage
{
    public class SoccerTeam : BaseEntity<Guid>
    {
        public string? TeamCode { get; set; }
        public string? TeamName { get; set; }       
    }
}
