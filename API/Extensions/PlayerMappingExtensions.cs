using MODELS.Entities;
using API.DTOs.PlayerDTOs;

namespace API.Extensions;

public static class PlayerMappingExtensions
{
    public static PlayerDto ToDto(this Player player)
    {
        return new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Class = player.Class, 
            Notes = player.Notes ?? string.Empty,
            
            // Map resources
            Resources = new PlayerResourcesDto
            {
                // Plants
                Nillea = player.Resources.Nillea,
                Tarmaret = player.Resources.Tarmaret,
                Albalacea = player.Resources.Albalacea,
                Mellis = player.Resources.Mellis,
                Anthemon = player.Resources.Anthemon,
                Saelicornia = player.Resources.Saelicornia,

                // Materials
                Scales = player.Resources.Scales,
                Bones = player.Resources.Bones,
                Blood = player.Resources.Blood,
                Zima = player.Resources.Zima,
                Iride = player.Resources.Iride,
                Kobaureo = player.Resources.Kobaureo,

                // Elements
                Fire = player.Resources.Fire,
                Horn = player.Resources.Horn,
                Coral = player.Resources.Coral,
                Crystal = player.Resources.Crystal,
                Thunder = player.Resources.Thunder,
                Metal = player.Resources.Metal,
                Feather = player.Resources.Feather,
                Venom = player.Resources.Venom,
                Ice = player.Resources.Ice
            },

            // Map skills
            Skills = [.. player.Skills
                .Select(s => new PlayerSkillDto
                {
                    Skill = s.Skill,
                    Level = s.Level
                })]
        };
    }

    // Optional helper for a collection
    public static IEnumerable<PlayerDto> ToDto(this IEnumerable<Player> players)
    {
        return players.Select(p => p.ToDto());
    }

    public static void UpdateResourcesFromDto(
        this Player player,
        PlayerResourcesDto dto)
    {
        var r = player.Resources;

        // Plants
        r.Nillea = dto.Nillea;
        r.Tarmaret = dto.Tarmaret;
        r.Albalacea = dto.Albalacea;
        r.Mellis = dto.Mellis;
        r.Anthemon = dto.Anthemon;
        r.Saelicornia = dto.Saelicornia;

        // Materials
        r.Scales = dto.Scales;
        r.Bones = dto.Bones;
        r.Blood = dto.Blood;
        r.Zima = dto.Zima;
        r.Iride = dto.Iride;
        r.Kobaureo = dto.Kobaureo;

        // Elements
        r.Fire = dto.Fire;
        r.Horn = dto.Horn;
        r.Coral = dto.Coral;
        r.Crystal = dto.Crystal;
        r.Thunder = dto.Thunder;
        r.Metal = dto.Metal;
        r.Feather = dto.Feather;
        r.Venom = dto.Venom;
        r.Ice = dto.Ice;
    }

    public static void UpdateSkillsFromDto(
        this Player player,
        IReadOnlyList<PlayerSkillDto> dtos)
    {
        player.Skills.Clear();

        foreach (var dto in dtos)
        {
            player.Skills.Add(new PlayerSkill
            {
                Skill = dto.Skill,
                Level = dto.Level
            });
        }
    }
}