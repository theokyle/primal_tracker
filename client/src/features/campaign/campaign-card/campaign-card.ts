import { Component, inject, input } from '@angular/core';
import { Campaign } from '../../../types/campaign';
import { RouterLink } from '@angular/router';
import { DeleteButton } from "../../../shared/delete-button/delete-button";
import { CampaignService } from '../../../core/service/campaign-service';

@Component({
  selector: 'app-campaign-card',
  imports: [RouterLink, DeleteButton],
  templateUrl: './campaign-card.html',
  styleUrl: './campaign-card.css',
})
export class CampaignCard {
  private campaignService = inject(CampaignService);
  public campaign = input.required<Campaign>()

  deleteCampaign(campaign: Campaign) {
    this.campaignService.deleteCampaign(campaign.id);
  }
}
