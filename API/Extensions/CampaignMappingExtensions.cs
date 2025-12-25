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

}
