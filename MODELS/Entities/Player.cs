using Microsoft.EntityFrameworkCore;

namespace MODELS.Entities;

public class Player
{
    public Guid Id { get; set; }
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; } = null!;

    public string Name { get; set; } = null!;
    public PlayerClass Class { get; set; }

    public List<PlayerSkill> Skills { get; set; } = [];
    public PlayerResources Resources { get; set; } = new();
    public string Notes { get; set; } = string.Empty;
}

public enum PlayerClass
{
    Hunter,
    Guardian,
    Tactician
}

[Owned]
public class PlayerSkill
{
    public SkillCode Skill { get; set; }
    public int Level { get; set; } // 0-2
}

public enum SkillCode
{
    A, B, C, D, E
}

[Owned]
public class PlayerResources
{
    // Plants
    public int Nillea { get; set; }
    public int Tarmaret { get; set; }
    public int Albalacea { get; set; }
    public int Mellis { get; set; }
    public int Anthemon { get; set; }
    public int Saelicornia { get; set; }

    // Materials
    public int Scales { get; set; }
    public int Bones { get; set; }
    public int Blood { get; set; }
    public int Zima { get; set; }
    public int Iride { get; set; }
    public int Kobaureo { get; set; }

    // Elements
    public int Fire { get; set; }
    public int Horn { get; set; }
    public int Coral { get; set; }
    public int Crystal { get; set; }
    public int Thunder { get; set; }
    public int Metal { get; set; }
    public int Feather { get; set; }
    public int Venom { get; set; }
    public int Ice { get; set; }
}