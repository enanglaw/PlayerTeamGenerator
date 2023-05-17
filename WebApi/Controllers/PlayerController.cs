// /////////////////////////////////////////////////////////////////////////////
// YOU CAN FREELY MODIFY THE CODE BELOW IN ORDER TO COMPLETE THE TASK
// /////////////////////////////////////////////////////////////////////////////

namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Entities;
using WebApi.Contracts.Persistence;
using AutoMapper;
using WebApi.DTO;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
  private readonly IPlayerRepository  _playerRepository;
    private readonly IPlayerSkillRepository _playerSkillRepository;
    private readonly IMapper _mapper;

    public PlayerController(IPlayerRepository playerRepository,IPlayerSkillRepository playerSkillRepository, IMapper mapper)
  {
    _playerRepository = playerRepository;
        _playerSkillRepository = playerSkillRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
  {
        try
        {
            var playerListAndSkill = (await _playerRepository.GetPlayerAndSkills()).OrderBy(s => s.Name);
            if (playerListAndSkill == null) return NotFound("No player with skills registered!");

            var mappedPlayerListAndSkill = _mapper.Map<List<Player>>(playerListAndSkill);

            return mappedPlayerListAndSkill;
        }
        catch (Exception ex)
        {
            return BadRequest("Error occured retrieving data " + ex.Message);
        }


  }

  
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostPlayer([FromBody] PlayerCreateOrUpdateDTO createDTO)
  {
        if (!ModelState.IsValid)
            return BadRequest($"Inputs:{createDTO} not valid for creation");
        try
        {
            var mappedPlayer = _mapper.Map<Player>(createDTO);
            

            var createResult = await _playerRepository.AddAsync(mappedPlayer);
           
            return CreatedAtAction(nameof(GetAll), new { id = createResult.Id }, createResult);

        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

  [HttpPut("{playerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Player>> PutPlayer(int playerId, [FromBody] PlayerCreateOrUpdateDTO updateDTO)
    {



        if (playerId != updateDTO.Id)
        {
            return BadRequest($"Could not find any player with provided Id:{playerId} for update");
        }
       var playerTobeUpdated= await _playerRepository.GetByIdAsync(playerId);
    
        try {
            // var mappedPlayerDto = _mapper.Map<Player>(updateDTO);
            _mapper.Map(updateDTO, playerTobeUpdated, typeof(PlayerCreateOrUpdateDTO), typeof(Player));
            await _playerRepository.UpdateAsync(playerId, playerTobeUpdated);
            return NoContent();

         }
         catch (Exception exception)
         {
             return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
         }
    }

  [HttpDelete("{playerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
   // [SwaggerOperation(Summary="Delete a player", Description=" A player to delete must exist otherwise NotFound is returned")]
   //[SwaggerResonse(204, "Success")]
   //[SwaggerResponse(404, "NotFound")]
    public async Task<ActionResult<Player>> DeletePlayer(int playerId)
  {
        try
        {
            var playerToDelete = await _playerRepository.DeleteAsync(playerId);
            if (!playerToDelete)
                return StatusCode((int)HttpStatusCode.Conflict, $"Failed to delete player with id: {playerId}");
           
            return NoContent();
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }
}