using System;
using API.DTOs.CampaignDTOs;
using MODELS.Entities;

namespace API.Extensions;

public static class CampaignStateMappingExtensions
{
    public static void UpdateFromDto(this CampaignState state, UpdateCampaignStateDto dto)
    {
        if (dto.Chapter.HasValue) state.Chapter = dto.Chapter.Value;
        if (dto.HerbalistLevel.HasValue) state.HerbalistLevel = dto.HerbalistLevel.Value;
        if (dto.ForgeLevel.HasValue) state.ForgeLevel = dto.ForgeLevel.Value;

        if (dto.Elements != null)
            state.UpdateElementsFromDto(dto.Elements);

        if (dto.Trophies != null)
            state.UpdateTrophiesFromDto(dto.Trophies);

        if (dto.Quests != null)
            state.UpdateQuestsFromDto(dto.Quests);

        if (dto.Achievements != null)
            state.Achievements = dto.Achievements.ToList();
    }

    public static CampaignElementsDto ToElementsDto(this CampaignState state)
    {
        return new CampaignElementsDto
        {
            Fire = state.Fire,
            Horn = state.Horn,
            Crystal = state.Crystal,
            Coral = state.Coral,
            Thunder = state.Thunder,
            Metal = state.Metal,
            Feather = state.Feather,
            Venom = state.Venom,
            Ice = state.Ice
        };
    }

    
    public static CampaignTrophiesDto ToTrophiesDto(this CampaignState state)
    {
        return new CampaignTrophiesDto
        {
            Vyraxen = state.Vyraxen,
            Kharia = state.Kharia,
            Toramat = state.Toramat,
            Dygorax = state.Dygorax,
            Korowon = state.Korowon,
            Orouxen = state.Orouxen,
            Felaxir = state.Felaxir,
            Morkraas = state.Morkraas,
            Ozew = state.Ozew,
            Jekoros = state.Jekoros,
            Hurom = state.Hurom,
            Tarragua = state.Tarragua,
            Hydar = state.Hydar,
            Reikal = state.Reikal,
            Sirkaaj = state.Sirkaaj,
            Mamuraak = state.Mamuraak,
            Pazis = state.Pazis,
            Nagarjas = state.Nagarjas,
            Zekath = state.Zekath,
            Zekalith = state.Zekalith,
            Taraska = state.Taraska,
            Xitheros = state.Xitheros
        };
    }

    public static void UpdateElementsFromDto(this CampaignState state, CampaignElementsUpdateDto dto)
    {
        if (dto.Fire.HasValue) state.Fire = dto.Fire.Value;
        if (dto.Horn.HasValue) state.Horn = dto.Horn.Value;
        if (dto.Crystal.HasValue) state.Crystal = dto.Crystal.Value;
        if (dto.Coral.HasValue) state.Coral = dto.Coral.Value;
        if (dto.Thunder.HasValue) state.Thunder = dto.Thunder.Value;
        if (dto.Metal.HasValue) state.Metal = dto.Metal.Value;
        if (dto.Feather.HasValue) state.Feather = dto.Feather.Value;
        if (dto.Venom.HasValue) state.Venom = dto.Venom.Value;
        if (dto.Ice.HasValue) state.Ice = dto.Ice.Value;
    }

    public static void UpdateTrophiesFromDto(this CampaignState state, CampaignTrophiesUpdateDto dto)
    {
        if (dto.Vyraxen.HasValue) state.Vyraxen = dto.Vyraxen.Value;
        if (dto.Kharia.HasValue) state.Kharia = dto.Kharia.Value;
        if (dto.Toramat.HasValue) state.Toramat = dto.Toramat.Value;
        if (dto.Dygorax.HasValue) state.Dygorax = dto.Dygorax.Value;
        if (dto.Korowon.HasValue) state.Korowon = dto.Korowon.Value;
        if (dto.Orouxen.HasValue) state.Orouxen = dto.Orouxen.Value;
        if (dto.Felaxir.HasValue) state.Felaxir = dto.Felaxir.Value;
        if (dto.Morkraas.HasValue) state.Morkraas = dto.Morkraas.Value;
        if (dto.Ozew.HasValue) state.Ozew = dto.Ozew.Value;
        if (dto.Jekoros.HasValue) state.Jekoros = dto.Jekoros.Value;
        if (dto.Hurom.HasValue) state.Hurom = dto.Hurom.Value;
        if (dto.Tarragua.HasValue) state.Tarragua = dto.Tarragua.Value;
        if (dto.Hydar.HasValue) state.Hydar = dto.Hydar.Value;
        if (dto.Reikal.HasValue) state.Reikal = dto.Reikal.Value;
        if (dto.Sirkaaj.HasValue) state.Sirkaaj = dto.Sirkaaj.Value;
        if (dto.Mamuraak.HasValue) state.Mamuraak = dto.Mamuraak.Value;
        if (dto.Pazis.HasValue) state.Pazis = dto.Pazis.Value;
        if (dto.Nagarjas.HasValue) state.Nagarjas = dto.Nagarjas.Value;
        if (dto.Zekath.HasValue) state.Zekath = dto.Zekath.Value;
        if (dto.Zekalith.HasValue) state.Zekalith = dto.Zekalith.Value;
        if (dto.Taraska.HasValue) state.Taraska = dto.Taraska.Value;
        if (dto.Xitheros.HasValue) state.Xitheros = dto.Xitheros.Value;
    }

    public static void UpdateQuestsFromDto(this CampaignState state, IReadOnlyList<QuestUpdateDto> dtos)
    {
        if (dtos == null) return;

        foreach (var dto in dtos)
        {
            var quest = state.Quests.FirstOrDefault(q => q.QuestNumber == dto.QuestNumber);
            if (quest != null && dto.Status.HasValue)
            {
                quest.Status = dto.Status.Value;
            }
        }
    }

    public static void UpdateQuestStatus(this CampaignState state, QuestUpdateDto dto)
    {
        var quest = state.Quests.FirstOrDefault(q => q.QuestNumber == dto.QuestNumber);
        if (quest != null && dto.Status.HasValue) quest.Status = dto.Status.Value;
    }

    public static QuestDto ToDto(this Quest quest)
    {
        return new QuestDto
        {
            QuestNumber = quest.QuestNumber,
            Status = quest.Status
        };
    }

    public static IReadOnlyList<QuestDto> ToDto(
        this IEnumerable<Quest> quests)
    {
        return quests.Select(q => q.ToDto()).ToList();
    }
}
