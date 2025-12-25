using API.DTOs.PlayerDTOs;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS.Entities;
using MODELS.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/campaigns/{campaignId:guid}/players")]
[Authorize]
public class PlayerController(ICampaignRepository campaignRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PlayerDto>>> GetPlayers(Guid campaignId)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        return Ok(campaign.Players.ToDto());
    }

    [HttpGet("{playerId:guid}")]
    public async Task<ActionResult<PlayerDto>> GetPlayer(Guid campaignId, Guid playerId)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        var player = campaign.Players.FirstOrDefault(p => p.Id == playerId);

        if (player == null) return NotFound();

        return player.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<PlayerDto>> CreatePlayer(Guid campaignId, CreatePlayerDto dto)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        var player = new Player
        {
            Name = dto.Name,
            Class = dto.Class,
            CampaignId = campaignId
        };

        campaign.Players.Add(player);

        await campaignRepository.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetPlayers),
            new { campaignId },
            player.ToDto());
    }

    [HttpPut("{playerId:guid}")]
    public async Task<ActionResult<PlayerDto>> UpdatePlayer(Guid campaignId, Guid playerId, UpdatePlayerDto dto)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignWithPlayersAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        var player = campaign.Players.FirstOrDefault(p => p.Id == playerId);
        if (player == null) return NotFound();

        player.Name = dto.Name ?? player.Name;
        player.Class = dto.Class ?? player.Class;
        player.Notes = dto.Notes ?? player.Notes;

        await campaignRepository.SaveChangesAsync();
        return player.ToDto();
    }

    [HttpPut("{playerId:guid}/resources")]
    public async Task<ActionResult<PlayerDto>> UpdatePlayerResources(Guid campaignId, Guid playerId, PlayerResourcesDto dto)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignWithPlayersAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        var player = campaign.Players.FirstOrDefault(p => p.Id == playerId);
        if (player == null) return NotFound();

        player.UpdateResourcesFromDto(dto);

        await campaignRepository.SaveChangesAsync();
        return player.ToDto();   
    }

    [HttpPut("{playerId:guid}/skills")]
    public async Task<ActionResult<PlayerDto>> UpdatePlayerSkills(Guid campaignId, Guid playerId, UpdatePlayerSkillsDto dto)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignWithPlayersAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        var player = campaign.Players.FirstOrDefault(p => p.Id == playerId);
        if (player == null) return NotFound();

        player.UpdateSkillsFromDto(dto.Skills);

        await campaignRepository.SaveChangesAsync();
        return player.ToDto();   
    }

    [HttpDelete("{playerId}")]
    public async Task<ActionResult> DeletePlayer(Guid campaignId, Guid playerId)
    {
        var userId = User.GetId();
        var campaign = await campaignRepository.GetCampaignWithPlayersAsync(campaignId);

        if (campaign == null || campaign.UserId != userId) return NotFound();

        var player = campaign.Players.FirstOrDefault(p => p.Id == playerId);

        if (player == null) return NotFound();

        campaign.Players.Remove(player);

        await campaignRepository.SaveChangesAsync();

        return NoContent();
    }

}
