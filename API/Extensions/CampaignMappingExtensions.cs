using API.DTOs.CampaignDTOs;
using MODELS.Entities;

namespace API.Extensions;

public static class CampaignMappingExtensions
{
    public static CampaignDto ToDto(this Campaign campaign)
    {
        if (campaign == null) return null!;

        return new CampaignDto
        {
            Id = campaign.Id,
            Name = campaign.Name,
            State = new CampaignStateDto
            {
                Chapter = campaign.State.Chapter,
                HerbalistLevel = campaign.State.HerbalistLevel,
                ForgeLevel = campaign.State.ForgeLevel,

                Elements = new CampaignElementsDto
                {
                    Fire = campaign.State.Fire,
                    Horn = campaign.State.Horn,
                    Crystal = campaign.State.Crystal,
                    Coral = campaign.State.Coral,
                    Thunder = campaign.State.Thunder,
                    Metal = campaign.State.Metal,
                    Feather = campaign.State.Feather,
                    Venom = campaign.State.Venom,
                    Ice = campaign.State.Ice
                },

                Trophies = new CampaignTrophiesDto
                {
                    Vyraxen = campaign.State.Vyraxen,
                    Kharia = campaign.State.Kharia,
                    Toramat = campaign.State.Toramat,
                    Dygorax = campaign.State.Dygorax,
                    Korowon = campaign.State.Korowon,
                    Orouxen = campaign.State.Orouxen,
                    Felaxir = campaign.State.Felaxir,
                    Morkraas = campaign.State.Morkraas,
                    Ozew = campaign.State.Ozew,
                    Jekoros = campaign.State.Jekoros,
                    Hurom = campaign.State.Hurom,
                    Tarragua = campaign.State.Tarragua,
                    Hydar = campaign.State.Hydar,
                    Reikal = campaign.State.Reikal,
                    Sirkaaj = campaign.State.Sirkaaj,
                    Mamuraak = campaign.State.Mamuraak,
                    Pazis = campaign.State.Pazis,
                    Nagarjas = campaign.State.Nagarjas,
                    Zekath = campaign.State.Zekath,
                    Zekalith = campaign.State.Zekalith,
                    Taraska = campaign.State.Taraska,
                    Xitheros = campaign.State.Xitheros
                },

                Quests = [.. campaign.State.Quests.Select(q => new QuestDto { QuestNumber = q.QuestNumber, Status = q.Status })],
                Achievements = campaign.State.Achievements?.ToList() ?? []
            },

            Players = campaign.Players?
                .Select(p => new PlayerSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Class = p.Class
                })
                .ToList() ?? []
        };
    }

    public static void UpdateStateFromDto(this Campaign campaign, UpdateCampaignStateDto dto)
        {
            campaign.State ??= new CampaignState();

            // Core values
            campaign.State.Chapter = dto.Chapter;
            campaign.State.HerbalistLevel = dto.HerbalistLevel;
            campaign.State.ForgeLevel = dto.ForgeLevel;

            // Elements
            campaign.State.Fire = dto.Elements.Fire;
            campaign.State.Horn = dto.Elements.Horn;
            campaign.State.Crystal = dto.Elements.Crystal;
            campaign.State.Coral = dto.Elements.Coral;
            campaign.State.Thunder = dto.Elements.Thunder;
            campaign.State.Metal = dto.Elements.Metal;
            campaign.State.Feather = dto.Elements.Feather;
            campaign.State.Venom = dto.Elements.Venom;
            campaign.State.Ice = dto.Elements.Ice;

            // Trophies
            campaign.State.Vyraxen = dto.Trophies.Vyraxen;
            campaign.State.Kharia = dto.Trophies.Kharia;
            campaign.State.Toramat = dto.Trophies.Toramat;
            campaign.State.Dygorax = dto.Trophies.Dygorax;
            campaign.State.Korowon = dto.Trophies.Korowon;
            campaign.State.Orouxen = dto.Trophies.Orouxen;
            campaign.State.Felaxir = dto.Trophies.Felaxir;
            campaign.State.Morkraas = dto.Trophies.Morkraas;
            campaign.State.Ozew = dto.Trophies.Ozew;
            campaign.State.Jekoros = dto.Trophies.Jekoros;
            campaign.State.Hurom = dto.Trophies.Hurom;
            campaign.State.Tarragua = dto.Trophies.Tarragua;
            campaign.State.Hydar = dto.Trophies.Hydar;
            campaign.State.Reikal = dto.Trophies.Reikal;
            campaign.State.Sirkaaj = dto.Trophies.Sirkaaj;
            campaign.State.Mamuraak = dto.Trophies.Mamuraak;
            campaign.State.Pazis = dto.Trophies.Pazis;
            campaign.State.Nagarjas = dto.Trophies.Nagarjas;
            campaign.State.Zekath = dto.Trophies.Zekath;
            campaign.State.Zekalith = dto.Trophies.Zekalith;
            campaign.State.Taraska = dto.Trophies.Taraska;
            campaign.State.Xitheros = dto.Trophies.Xitheros;

            // Lists
            foreach (var questDto in dto.Quests)
            {
                var quest = campaign.State.Quests.FirstOrDefault(q => q.QuestNumber == questDto.QuestNumber);
                quest?.Status = questDto.Status;
            }

            campaign.State.Achievements = dto.Achievements ?? [];
        }
}
