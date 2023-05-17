using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.Persistence;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Player>> GetPlayerAndSkills(int playerId)
        {
            var matchedPlayerAndSkills = await (from playerAndSkills in _dbContext.Players.Include(s => s.PlayerSkills) where playerAndSkills.Id == playerId select playerAndSkills).ToListAsync();
            return matchedPlayerAndSkills;
        }
        public async Task<IEnumerable<Player>> GetPlayerAndSkills()
        {
            var matchedPlayerAndSkills = await (from playerAndSkills in _dbContext.Players.Include(s => s.PlayerSkills) select playerAndSkills).ToListAsync();
            return matchedPlayerAndSkills;
        }

        public async Task<IEnumerable<Player>> GetTeam(string position, string mainSkill, int numberOfPlayers)
        {
          var matchedPlayerAndSkills = await (_dbContext.Players.Include(s => s.PlayerSkills).Where(p => p.Position == position).Select(b => new Player
            {
                Id=b.Id,
                Name=b.Name,
                Position = b.Position,
                PlayerSkills = b.PlayerSkills.Select(s => new PlayerSkill { Skill = s.Skill, Value = s.Value, PlayerId=s.PlayerId,Id=s.Id })
                .Where(s => s.Skill == mainSkill).ToList()})).ToListAsync();

           
            return matchedPlayerAndSkills;
        }
    }
}

