import { Component, inject } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';
import { RouterLink, RouterLinkActive, RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-campaign-detail',
  imports: [RouterLinkActive, RouterOutlet, RouterLink],
  templateUrl: './campaign-detail.html',
  styleUrl: './campaign-detail.css',
})
export class CampaignDetail {
  protected campaignService = inject(CampaignService);
}
