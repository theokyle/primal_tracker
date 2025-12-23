

using Microsoft.EntityFrameworkCore;
using MODELS.Config;

namespace MODELS.Entities;

public class Campaign
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public List<Player> Players { get; set; } = [];
    public CampaignState State { get; set; } = new();
}

[Owned]
public class CampaignState
{
    // Core campaign tracking
    public int Chapter { get; set; } = 1;
    public int HerbalistLevel { get; set; } = 1;
    public int ForgeLevel { get; set; } = 1;

    // Elements 
    public bool Fire { get; set; }
    public bool Horn { get; set; }
    public bool Crystal { get; set; }
    public bool Coral { get; set; }
    public bool Thunder { get; set; }
    public bool Metal { get; set; }
    public bool Feather { get; set; }
    public bool Venom { get; set; }
    public bool Ice { get; set; }

    // Trophies
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
    public List<Quest> Quests { get; set; } = [];
    public List<string> Achievements { get; set; } = [];

    public CampaignState()
    {
        for (int i = 1; i <= GameConfig.TotalQuests; i++)
        {
            Quests.Add(new Quest {QuestNumber = i});
        }
    }
}

public class Quest
{
    public int QuestNumber { get; set; }
    public QuestStatus Status { get; set; } = QuestStatus.Locked;
}

public enum QuestStatus
{
    Unlocked,
    Completed,
    Locked, 
    Expired
}