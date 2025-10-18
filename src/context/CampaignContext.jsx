import { createContext, useEffect, useState } from 'react';
import api from "../api/api.js";

export const CampaignContext = createContext();

export function CampaignProvider({children, campaignId}) {
    const [campaign, setCampaign] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    // UseEffect Hook to fetch data
    useEffect(() => {
        api.get(`/campaign/${campaignId}`)
        .then(res => setCampaign(res.data))
        .catch(err => setError(err.message))
        .finally(() => setLoading(false))
    }, [])

    // Update chapter

    // Update Forge

    // Update Herbalist

    // Update Elements

    // Update Trophies

    // Add Achievement

    // Add Player

    // Remove Player
}