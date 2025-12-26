import { Component, inject } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';
import { KeyValuePipe, NgClass, TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-campaign-trophies',
  imports: [KeyValuePipe, NgClass, TitleCasePipe],
  templateUrl: './campaign-trophies.html',
  styleUrl: './campaign-trophies.css',
})
export class CampaignTrophies {
  protected campaignService = inject(CampaignService);

}
