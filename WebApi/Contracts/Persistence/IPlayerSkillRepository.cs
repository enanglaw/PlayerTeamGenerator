using WebApi.Entities;

namespace WebApi.Contracts.Persistence
{
    public interface IPlayerSkillRepository : IAsyncBaseRepository<PlayerSkill>
    {
        Task<IEnumerable<PlayerSkill>> PlayerSkills(int playerId);
       

    }
}
