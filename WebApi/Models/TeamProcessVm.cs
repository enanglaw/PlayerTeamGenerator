using System.ComponentModel.DataAnnotations;
using WebApi.DTO;

namespace WebApi.Models
{
    public class TeamProcessVm
    {

            [Required]
            public string Position { get; set; }
            [Required]
            public string MainSkill { get; set; }
            [Required]
            public int NumberOfPlayers { get; set; }

    }
}
