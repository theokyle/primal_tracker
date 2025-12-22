using System;
using MODELS.Entities;

namespace MODELS.Interfaces;

public interface IPlayerRepository
{
    Task<IReadOnlyList<Player>> GetPlayersByCampaignAsync(Guid campaignId);
    Task<Player?> GetPlayerByIdAsync(Guid id);
    void AddPlayer(Player player);
    void UpdatePlayer(Player player);
    void DeletePlayer(Player player);
    bool PlayerExists(Guid id);
    Task<bool> SaveChangesAsync();

}
