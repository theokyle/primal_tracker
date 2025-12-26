import { Component, computed, inject } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';
import { KeyValuePipe, NgClass, TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-campaign-status',
  imports: [KeyValuePipe, NgClass, TitleCasePipe],
  templateUrl: './campaign-status.html',
  styleUrl: './campaign-status.css',
})
export class CampaignStatus {
  protected campaignService = inject(CampaignService);
  protected chapters = computed(() => {
    const campaign = this.campaignService.currentCampaign();
    const currentChapter = campaign?.state.chapter ?? 0;

    return Array.from({ length: 11 }, (_, index) => index + 1 === currentChapter);
  });
  protected herbalist = computed(() => {
    const campaign = this.campaignService.currentCampaign();
    const herbalistLevel = campaign?.state.herbalistLevel ?? 0;

    return Array.from({ length: 3 }, (_, index) => index + 1 === herbalistLevel);
  });
  protected forge = computed(() => {
    const campaign = this.campaignService.currentCampaign();
    const forgeLevel = campaign?.state.forgeLevel ?? 0;

    return Array.from({ length: 3 }, (_, index) => index + 1 === forgeLevel);
  });
}
