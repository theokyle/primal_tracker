import { inject } from '@angular/core';
import { ResolveFn, Router } from '@angular/router';
import { CampaignService } from '../../core/service/campaign-service';
import { EMPTY } from 'rxjs';
import { Campaign } from '../../types/campaign';

export const campaignResolver: ResolveFn<Campaign> = (route, state) => {
  const campaignService = inject(CampaignService);
  const router = inject(Router);
  const campaignId = route.paramMap.get('id');

  if (!campaignId) {
    router.navigateByUrl('/not-found');
    return EMPTY
  }

  return campaignService.getCampaign(campaignId);
};
