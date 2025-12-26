import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Campaign } from '../../types/campaign';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CampaignService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  editMode = signal(false);
  currentCampaign = signal<Campaign | null>(null);

  getCampaigns() {
    return this.http.get<Campaign[]>(this.baseUrl + 'campaigns')
  }

  getCampaign(campaignId : string) {
    return this.http.get<Campaign>(this.baseUrl + 'campaigns/' + campaignId).pipe(
      tap(campaign => this.currentCampaign.set(campaign))
    );
  }
  
}
