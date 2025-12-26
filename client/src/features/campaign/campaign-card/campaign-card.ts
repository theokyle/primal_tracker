import { Component, input } from '@angular/core';
import { Campaign } from '../../../types/campaign';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-campaign-card',
  imports: [RouterLink],
  templateUrl: './campaign-card.html',
  styleUrl: './campaign-card.css',
})
export class CampaignCard {
  public campaign = input.required<Campaign>()
}
