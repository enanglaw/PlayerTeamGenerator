using WebApi.DTO;

namespace WebApi.Models
{
    public class PlayerListVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<PlayerListSkillsDTO> Skills { get; set; }
    }
}
