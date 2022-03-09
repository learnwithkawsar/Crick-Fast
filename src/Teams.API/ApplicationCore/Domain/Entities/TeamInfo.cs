using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Teams.API.ApplicationCore.Domain.Entities
{
    public class TeamInfo : BaseEntity
    {
       
        [Required]
        public string TeamName { get; set; }
        public string CountryName { get; set; }
        public string ShortCode { get; set; }
    }
}
