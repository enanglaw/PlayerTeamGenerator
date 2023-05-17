using WebApi.DTO;

namespace WebApi.Models
{
    public class PlayerSkillListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<PlayerSkillDTO> Skills { get; set; }
    }
}
