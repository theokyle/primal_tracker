using System;
using MODELS.Entities;

namespace API.DTOs.PlayerDTOs;

public class CreatePlayerDto
{
    public string Name { get; set; } = null!;
    public PlayerClass Class { get; set; }
    public string Notes { get; set; } = string.Empty;

    public PlayerResourcesDto Resources { get; set; } = new();
    public List<PlayerSkillDto> Skills { get; set; } = new();
}

public class UpdatePlayerDto
{
    public string? Name { get; set; }            // Nullable for partial updates
    public PlayerClass? Class { get; set; }
    public string? Notes { get; set; }

    public PlayerResourcesDto? Resources { get; set; }
    public List<PlayerSkillDto>? Skills { get; set; }
}