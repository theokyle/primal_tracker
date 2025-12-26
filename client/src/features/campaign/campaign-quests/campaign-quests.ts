import { Component, inject } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';
import { QuestStatus } from '../../../types/campaign';

@Component({
  selector: 'app-campaign-quests',
  imports: [],
  templateUrl: './campaign-quests.html',
  styleUrl: './campaign-quests.css',
})
export class CampaignQuests {
  protected campaignService = inject(CampaignService);
  protected questStatus = QuestStatus;
}
