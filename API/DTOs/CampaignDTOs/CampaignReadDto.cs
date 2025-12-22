using System;
using MODELS.Entities;

namespace API.DTOs.CampaignDTOs;

public class CampaignDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public CampaignStateDto State { get; set; } = new();
    public IReadOnlyList<PlayerSummaryDto> Players { get; set; } = [];
}

public class CampaignStateDto
{
    public int Chapter { get; set; }
    public int HerbalistLevel { get; set; }
    public int ForgeLevel { get; set; }

    public CampaignElementsDto Elements { get; set; } = new();
    public CampaignTrophiesDto Trophies { get; set; } = new();

    public IReadOnlyList<int> CompletedQuests { get; set; } = [];
    public IReadOnlyList<string> Achievements { get; set; } = [];
}

public class CampaignElementsDto
{
    public bool Fire { get; set; }
    public bool Horn { get; set; }
    public bool Crystal { get; set; }
    public bool Coral { get; set; }
    public bool Thunder { get; set; }
    public bool Metal { get; set; }
    public bool Feather { get; set; }
    public bool Venom { get; set; }
    public bool Ice { get; set; }
}

public class CampaignTrophiesDto
{
    public bool Vyraxen { get; set; }
    public bool Kharia { get; set; }
    public bool Toramat { get; set; }
    public bool Dygorax { get; set; }
    public bool Korowon { get; set; }
    public bool Orouxen { get; set; }
    public bool Felaxir { get; set; }
    public bool Morkraas { get; set; }
    public bool Ozew { get; set; }
    public bool Jekoros { get; set; }
    public bool Hurom { get; set; }
    public bool Tarragua { get; set; }
    public bool Hydar { get; set; }
    public bool Reikal { get; set; }
    public bool Sirkaaj { get; set; }
    public bool Mamuraak { get; set; }
    public bool Pazis { get; set; }
    public bool Nagarjas { get; set; }
    public bool Zekath { get; set; }
    public bool Zekalith { get; set; }
    public bool Taraska { get; set; }
    public bool Xitheros { get; set; }
}

public class PlayerSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public PlayerClass Class { get; set; }
}