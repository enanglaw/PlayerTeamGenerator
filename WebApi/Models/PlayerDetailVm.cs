using System.ComponentModel.DataAnnotations;
using WebApi.DTO;
using WebApi.Entities;

namespace WebApi.Models
{
    public class PlayerDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
        public List<PlayerDetailSkillsDTO> Skills { get; set; }
    }
}
