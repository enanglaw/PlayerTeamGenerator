namespace WebApi.DTO
{
    public class PlayerSkillDTO
    {
        public int Id { get; set; }
        public string Skill { get; set; } = string.Empty;
        public int Value { get; set; }
        public int PlayerId { get; set; }
    }
}
