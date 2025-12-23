using Api.Controllers;
using API.DTOs.CampaignDTOs;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS.Entities;
using MODELS.Interfaces;

namespace API.Controllers;

[Authorize]
public class CampaignsController(ICampaignRepository campaignRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CampaignDto>>> GetCampaigns()
    {
        var userId = User.GetId();

        var campaigns = await campaignRepository.GetCampaignsAsync(userId);

        return Ok(campaigns.Select(c => c.ToDto()));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CampaignDto>> GetCampaign(Guid id)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(id);

        if (campaign == null || userId != campaign.UserId) return NotFound();

        return campaign.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<CampaignDto>> CreateCampaign(CreateCampaignDto dto)
    {
        var userId = User.GetId();
        
        var campaign = new Campaign
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            UserId = userId
        };

        campaignRepository.AddCampaign(campaign);
        bool success = await campaignRepository.SaveChangesAsync();
        if (!success) return BadRequest("Unable to create campaign");
        
        return CreatedAtAction("GetCampaign", new {id = campaign.Id}, campaign.ToDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CampaignDto>> UpdateCampaign(Guid id, UpdateCampaignStateDto dto)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(id);

        if (campaign == null || campaign.UserId != userId)
            return NotFound();

        campaign.UpdateStateFromDto(dto);

        var success = await campaignRepository.SaveChangesAsync();
        if (!success)
            return BadRequest("Failed to update campaign");

        return Ok(campaign.ToDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCampaign(Guid id)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(id);

        if (campaign == null || campaign.UserId != userId)
            return NotFound();

        campaignRepository.DeleteCampaign(campaign);

        var success = await campaignRepository.SaveChangesAsync();
        if (!success) return BadRequest("Error deleting campaign");
        return NoContent();
    }
}
