using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.Persistence;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Repositories
{
    public class PlayerSkillRepository : BaseRepository<PlayerSkill>, IPlayerSkillRepository

    {
        public PlayerSkillRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PlayerSkill>> PlayerSkills(int playerId)
        {
            var matchedPlayerAndSkills = await (from playerAndSkills in _dbContext.PlayerSkills
                                                where playerAndSkills.PlayerId == playerId
                                                group playerAndSkills by playerAndSkills.Id into newPlayerAndSkills
                                                select newPlayerAndSkills.FirstOrDefault().Id).ToListAsync(); 
            return (IEnumerable<PlayerSkill>)matchedPlayerAndSkills;
        }
    }
}
