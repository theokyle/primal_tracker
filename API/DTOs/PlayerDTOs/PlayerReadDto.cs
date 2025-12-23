using System;
using System.Text.Json.Serialization;
using MODELS.Entities;

namespace API.DTOs.PlayerDTOs;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PlayerClass Class { get; set; }

    public PlayerResourcesDto Resources { get; set; } = new();
    public IReadOnlyList<PlayerSkillDto> Skills { get; set; } = [];
    public string Notes { get; set; } = string.Empty;
}

public class PlayerResourcesDto
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

public class PlayerSkillDto
{
    public int Id { get; set; }       // Internal DB id
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SkillCode Skill { get; set; }  // Enum: A-E
    public int Level { get; set; }    // 1-2
}