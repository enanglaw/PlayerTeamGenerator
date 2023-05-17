using AutoMapper;
using WebApi.DTO;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PlayerSkill, PlayerSkillDTO>().ReverseMap();
            CreateMap<PlayerSkill, PlayerDetailSkillsDTO>().ReverseMap();

            CreateMap<Player, PlayerListVm>();
            CreateMap<PlayerListVm, Player>().ForMember(s => s.PlayerSkills, s => s.MapFrom(MapPlayerListSkills));
            CreateMap<UpdatePlayerDto, Player>().ReverseMap();
            CreateMap<PlayerUpdateDTO, UpdatePlayerDto>().ReverseMap();
            CreateMap<Player, PlayerCreateOrUpdateDTO>().ReverseMap();

            CreateMap<Player, TeamSkillsResponseVm>().ReverseMap();

            CreateMap<Player, PlayerSkillListVM>();
            CreateMap<PlayerSkillListVM, Player>()
             .ForMember(m => m.PlayerSkills, m => m.MapFrom(MapPlayerSkill));
            CreateMap<Player, PlayerDetailVm>();
            CreateMap<PlayerDetailVm, Player>().ForMember(p => p.PlayerSkills, p => p.MapFrom(MapPlayerDetailAndSkill));
            CreateMap<PlayerUpdateDTO, Player>()
               .ForMember(m => m.PlayerSkills, m => m.MapFrom(MapPlayerAndSkill));
            CreateMap<Player, PlayerUpdateDTO>();
            CreateMap<PlayerCreateOrUpdateDTO, Player>()
               .ForMember(m => m.PlayerSkills, m => m.MapFrom(MapPlayerAndSkillCreation));
            CreateMap<Player, PlayerCreateOrUpdateDTO>().ReverseMap();

        }

        private List<PlayerDetailSkillsDTO> MapPlayerAndSkillCreation(PlayerCreateOrUpdateDTO playerCreate, Player player)
        {
            var result = new List<PlayerDetailSkillsDTO>();
            try
            {
                if (playerCreate.PlayerSkills == null) return result;
                foreach (var playerAndSkillDetail in playerCreate.PlayerSkills)
                {
                    result.Add(new PlayerDetailSkillsDTO()
                    {
                        Value = playerAndSkillDetail.Value,
                        Id = playerAndSkillDetail.Id,
                        Skill = playerAndSkillDetail.Skill
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while coverting player skills " + ex.Message);
                throw ex;


            }
        }

        private List<PlayerDetailSkillsDTO> MapPlayerAndSkill(PlayerUpdateDTO playerUpdate, Player player)
        {
            var result = new List<PlayerDetailSkillsDTO>();
            try
            {
                if (playerUpdate.PlayerSkills == null) return result;
                foreach (var playerAndSkillDetail in playerUpdate.PlayerSkills)
                {
                    result.Add(new PlayerDetailSkillsDTO()
                    {
                        Value = playerAndSkillDetail.Value,
                        Id = playerAndSkillDetail.Id,
                        Skill = playerAndSkillDetail.Skill
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while coverting player skills " + ex.Message);
                throw ex;


            }
        }

        private List<PlayerDetailSkillsDTO> MapPlayerDetailAndSkill(PlayerDetailVm playerDetailVm, Player player)
        {
            var result = new List<PlayerDetailSkillsDTO>();
            try
            {
                if (playerDetailVm.Skills == null) return result;
                foreach (var playerAndSkillDetail in playerDetailVm.Skills)
                {
                    result.Add(new PlayerDetailSkillsDTO()
                    {
                        Value = playerAndSkillDetail.Value,
                        Id = playerAndSkillDetail.Id,
                        Skill = playerAndSkillDetail.Skill
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while coverting player skills " + ex.Message);
                throw ex;


            }
        }
        private List<PlayerListSkillsDTO> MapPlayerListSkills(PlayerListVm playerListVm, Player player)
        {
            var result = new List<PlayerListSkillsDTO>();
            try
            {
                if (playerListVm.Skills == null) return result;
                foreach (var playerListSkill in playerListVm.Skills)
                {
                    result.Add(new PlayerListSkillsDTO()
                    {
                        Value = playerListSkill.Value,
                        Id = playerListSkill.Id,
                        Skill = playerListSkill.Skill
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while coverting player skills " + ex.Message);
                throw ex;

            }
        }

        private List<PlayerSkillDTO> MapPlayerSkill(PlayerSkillListVM playerListVM, Player player)
        {

            var result = new List<PlayerSkillDTO>();
            try
            {
                if (playerListVM.Skills == null) return result;
                foreach (var playerSkills in playerListVM.Skills)
                {
                    result.Add(new PlayerSkillDTO()
                    {
                        Value = playerSkills.Value,
                        Id = playerSkills.Id,
                        Skill = playerSkills.Skill

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while coverting Leader Media " + ex.Message);
                throw ex;

            }
        }

    }
}

