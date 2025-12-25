using System;
using MODELS.Entities;

namespace API.DTOs.PlayerDTOs;

public class CreatePlayerDto
{
    public string Name { get; set; } = null!;
    public PlayerClass Class { get; set; }
    public string Notes { get; set; } = string.Empty;

    public PlayerResourcesDto Resources { get; set; } = new();
    public List<PlayerSkillDto> Skills { get; set; } = [];
}

public class UpdatePlayerDto
{
    public string? Name { get; set; }            
    public PlayerClass? Class { get; set; }
    public string? Notes { get; set; }

}

public class UpdatePlayerSkillsDto
{
    public IReadOnlyList<PlayerSkillDto> Skills { get; set; } = [];
}