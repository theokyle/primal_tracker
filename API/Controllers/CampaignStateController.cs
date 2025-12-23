using System;
using API.DTOs.CampaignDTOs;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/campaigns/{campaignId:guid}/state")]
[Authorize]
public class CampaignStateController(ICampaignRepository campaignRepository) : ControllerBase 
{
    [HttpGet]
    public async Task<ActionResult<CampaignStateDto>> GetCampaign(Guid campaignId)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || userId != campaign.UserId) return NotFound();

        return campaign.ToDto().State;
    }

    [HttpPut("elements")]
    public async Task<ActionResult<CampaignElementsDto>> UpdateElements(Guid campaignId, CampaignElementsUpdateDto dto)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || userId != campaign.UserId) return NotFound();

        campaign.State.UpdateElementsFromDto(dto);

        await campaignRepository.SaveChangesAsync();

        return campaign.State.ToElementsDto();
    }

    [HttpPut("trophies")]
    public async Task<ActionResult<CampaignTrophiesDto>> UpdateTrophies(Guid campaignId, CampaignTrophiesUpdateDto dto)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || userId != campaign.UserId) return NotFound();

        campaign.State.UpdateTrophiesFromDto(dto);

        await campaignRepository.SaveChangesAsync();

        return campaign.State.ToTrophiesDto();
    }

    [HttpPut("quests")]
    public async Task<ActionResult<IReadOnlyList<QuestDto>>> UpdateQuests(Guid campaignId, IReadOnlyList<QuestUpdateDto> dtos)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || userId != campaign.UserId) return NotFound();

        campaign.State.UpdateQuestsFromDto(dtos);

        await campaignRepository.SaveChangesAsync();

        return Ok(campaign.State.Quests.ToDto());
    }

    [HttpPut("quests/{questNumber:int}")]
    public async Task<ActionResult<IReadOnlyList<QuestDto>>> UpdateQuest(Guid campaignId, int questNumber, QuestUpdateDto dto)
    {
        var userId = User.GetId();

        var campaign = await campaignRepository.GetCampaignByIdAsync(campaignId);

        if (campaign == null || userId != campaign.UserId) return NotFound();

        if (dto.Status == null) return BadRequest(); 

        campaign.State.UpdateQuestStatus(dto);

        await campaignRepository.SaveChangesAsync();

        return Ok(campaign.State.Quests.ToDto());
    }

}
