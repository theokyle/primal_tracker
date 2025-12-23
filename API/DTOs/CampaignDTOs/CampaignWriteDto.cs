using System;

namespace API.DTOs.CampaignDTOs;

public class CreateCampaignDto
{
    public string Name { get; set; } = "";
}

public class UpdateCampaignStateDto
{
    public int Chapter { get; set; }
    public int HerbalistLevel { get; set; }
    public int ForgeLevel { get; set; }

    public CampaignElementsDto Elements { get; set; } = new();
    public CampaignTrophiesDto Trophies { get; set; } = new();

    public List<QuestDto> Quests { get; set; } = [];
    public List<string> Achievements { get; set; } = [];
}