export type Campaign = {
  id: string;
  name: string;
  userId: string;
  state: CampaignState;
}

export type CampaignState = {
  chapter: number;
  forgeLevel: number;
  herbalistLevel: number;

  elements: CampaignElements;
  trophies: CampaignTrophies;

  quests: Quest[];
  achievements: string[];
}

export type CampaignElements = {
  fire: boolean;
  ice: boolean;
  thunder: boolean;
  venom: boolean;
  crystal: boolean;
  metal: boolean;
  coral: boolean;
  feather: boolean;
  horn: boolean;
}

export type CampaignTrophies = {
  vyraxen: boolean;
  kharia: boolean;
  hurom: boolean;
  hydar: boolean;
  jekoros: boolean;
  mamuraak: boolean;
  morkraas: boolean;
  nagarjas: boolean;
  orouxen: boolean;
  pazis: boolean;
  reikal: boolean;
  sirkaaj: boolean;
  taraska: boolean;
  tarragua: boolean;
  toramat: boolean;
  xitheros: boolean;
  zekalith: boolean;
  zekath: boolean;
}

export type Quest = {
  questNumber: number;
  status: QuestStatus;
}

export enum QuestStatus {
  Locked = 'Locked',
  Unlocked = 'Unlocked',
  Completed = 'Completed',
  Expired = 'Expired'
}
