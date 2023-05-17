using System.ComponentModel.DataAnnotations;
using WebApi.DTO;

namespace WebApi.Models
{
    public class TeamSkillsResponseVm
    {

       
        public string Position { get; set; }
       
        public string MainSkill { get; set; }
        public List<TeamSkillsDto> TeamSkills { get; set; }
    }
}
