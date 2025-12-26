import { Routes } from '@angular/router';
import { Home } from '../features/home/home';
import { CampaignList } from '../features/campaign/campaign-list/campaign-list';
import { CampaignDetail } from '../features/campaign/campaign-detail/campaign-detail';
import { CampaignTrophies } from '../features/campaign/campaign-trophies/campaign-trophies';
import { CampaignStatus } from '../features/campaign/campaign-status/campaign-status';
import { CampaignQuests } from '../features/campaign/campaign-quests/campaign-quests';
import { CampaignAchievements } from '../features/campaign/campaign-achievements/campaign-achievements';
import { NotFound } from '../shared/not-found/not-found';
import { campaignResolver } from '../features/campaign/campaign-resolver';

export const routes: Routes = [
    {path: '', component: Home},
    {
        path: '',
        children: [
            {path: 'campaigns', component: CampaignList},
            {
                path: 'campaigns/:id',
                runGuardsAndResolvers: 'always',
                resolve: {campaign: campaignResolver},
                component: CampaignDetail,
                children: [
                    {path: '', redirectTo: 'status', pathMatch: 'full'},
                    {path: 'status', component: CampaignStatus},
                    {path: 'trophies', component: CampaignTrophies},
                    {path: 'quests', component: CampaignQuests},
                    {path: 'achievements', component: CampaignAchievements}
                ]
            }
        ]
    },
    {path: '**', component: NotFound}
];
