namespace WebApi.DTO
{
    public class PlayerCreateOrUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<PlayerSkillDTO> PlayerSkills { get; set; }
    }
}
