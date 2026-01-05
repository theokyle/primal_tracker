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
  campaigns = signal<Campaign[]>([]);

  loadCampaigns() {
    this.http.get<Campaign[]>(this.baseUrl + 'campaigns').subscribe(list => this.campaigns.set(list));
  }

  getCampaign(campaignId : string) {
    return this.http.get<Campaign>(this.baseUrl + 'campaigns/' + campaignId).pipe(
      tap(campaign => this.currentCampaign.set(campaign))
    );
  }

  deleteCampaign(campaignId : string) {
    return this.http.delete(this.baseUrl + 'campaigns/' + campaignId).pipe(
      tap(() => {
          this.campaigns.update(list => list.filter(c => c.id != campaignId));
          if (this.currentCampaign()?.id == campaignId) {
            this.currentCampaign.set(null);
          }
        })
      ).subscribe();
  }

  createCampaign(campaign : Campaign) {
    return this.http.post<Campaign>(this.baseUrl + 'campaigns', campaign).pipe(
      tap(campaign => {
        this.campaigns.update(list => [...list, campaign]);
        this.currentCampaign.set(campaign);
      })
    ).subscribe();
  }
}
