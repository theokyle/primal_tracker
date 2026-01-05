import { Component, inject, OnInit } from '@angular/core';
import { CampaignService } from '../../../core/service/campaign-service';
import { CampaignCard } from '../campaign-card/campaign-card';

@Component({
  selector: 'app-campaign-list',
  imports: [CampaignCard],
  templateUrl: './campaign-list.html',
  styleUrl: './campaign-list.css',
})
export class CampaignList implements OnInit {
  protected campaignService = inject(CampaignService);

  ngOnInit() {
    this.campaignService.loadCampaigns();
  } 
}
