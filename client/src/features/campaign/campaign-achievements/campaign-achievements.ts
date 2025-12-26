import { Component, inject } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';

@Component({
  selector: 'app-campaign-achievements',
  imports: [],
  templateUrl: './campaign-achievements.html',
  styleUrl: './campaign-achievements.css',
})
export class CampaignAchievements {
  protected campaignService = inject(CampaignService);
}
