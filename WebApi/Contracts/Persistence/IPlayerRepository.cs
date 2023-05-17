using WebApi.Entities;

namespace WebApi.Contracts.Persistence
{
    public interface IPlayerRepository:IAsyncBaseRepository<Player>
    {
        Task<IEnumerable<Player>> GetPlayerAndSkills(int playerId);
        Task<IEnumerable<Player>> GetPlayerAndSkills();
        Task<IEnumerable<Player>> GetTeam(string position, string mainSkill, int numberOfPlayers);
    }
}
