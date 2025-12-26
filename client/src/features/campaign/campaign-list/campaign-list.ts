import { Component, inject } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';
import { Observable } from 'rxjs';
import { Campaign } from '../../../types/campaign';
import { AsyncPipe } from '@angular/common';
import { CampaignCard } from '../campaign-card/campaign-card';

@Component({
  selector: 'app-campaign-list',
  imports: [AsyncPipe, CampaignCard],
  templateUrl: './campaign-list.html',
  styleUrl: './campaign-list.css',
})
export class CampaignList {
  private campaignService = inject(CampaignService);
  protected campaigns$: Observable<Campaign[]>

  constructor() {
    this.campaigns$ = this.campaignService.getCampaigns();
  }
}
