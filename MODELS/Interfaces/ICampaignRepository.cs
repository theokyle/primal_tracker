using System;
using MODELS.Entities;

namespace MODELS.Interfaces;

public interface ICampaignRepository
{
    Task<IReadOnlyList<Campaign>> GetCampaignsAsync(Guid userId);
    Task<Campaign?> GetCampaignByIdAsync(Guid id);
    Task<Campaign?> GetCampaignWithPlayersAsync(Guid id);
    void AddCampaign(Campaign campaign);
    void DeleteCampaign(Campaign campaign);
    bool CampaignExists(Guid id);
    Task<bool> SaveChangesAsync();
}
