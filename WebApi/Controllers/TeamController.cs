// /////////////////////////////////////////////////////////////////////////////
// YOU CAN FREELY MODIFY THE CODE BELOW IN ORDER TO COMPLETE THE TASK
// /////////////////////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Persistence;
using WebApi.Entities;
using WebApi.Helpers;

using System.Net;
using WebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController
    {
        
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public TeamController(IMapper mapper, IPlayerRepository playerRepository)
        {
            _mapper = mapper;
           _playerRepository = playerRepository;
        }

        [HttpPost("process")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Player>>> Process([FromBody]List<TeamProcessVm> teamsParams)
        {
            List<Player> players = new List<Player>();
            if (teamsParams.Count > 0)
            {
                foreach(var team in teamsParams)
                {
                   players= (List<Player>)await _playerRepository.GetTeam(team.Position, team.MainSkill, team.NumberOfPlayers);
                }
            }
            var matedBestPlayer = _mapper.Map<Player>(players);

            var response = _mapper.Map<TeamSkillsResponseVm>(matedBestPlayer);
            //Not completed yet
            return players;


        }
    }
}
