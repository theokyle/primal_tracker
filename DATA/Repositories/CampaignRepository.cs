using System;
using MODELS.Entities;
using MODELS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DATA.Repositories;

public class CampaignRepository(AppDbContext context) : ICampaignRepository
{
    public void AddCampaign(Campaign campaign)
    {
        context.Campaigns.Add(campaign);
    }

    public bool CampaignExists(Guid id)
    {
        return context.Campaigns.Any(x => x.Id == id);
    }

    public void DeleteCampaign(Campaign campaign)
    {
        context.Campaigns.Remove(campaign);
    }

    public async Task<Campaign?> GetCampaignByIdAsync(Guid id)
    {
        return await context.Campaigns.FindAsync(id);
    }

    public async Task<IReadOnlyList<Campaign>> GetCampaignsAsync(Guid userId)
    {
        return await context.Campaigns.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Campaign?> GetCampaignWithPlayersAsync(Guid id)
    {
        return await context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.Resources)
            .Include(c => c.Players)
                .ThenInclude(p => p.Skills)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
