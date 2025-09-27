import { createContext, useEffect, useState } from 'react';
import { samplePlayer } from '../assets/sampleData';

export const PlayerContext = createContext();

export const PlayerProvider = ({children}) => {
    const [player, setPlayer] = useState(null);

    // UseEffect Hook to fetch data from DB
    useEffect(() => {
        try {
            setPlayer(samplePlayer);
        } catch (err) {
            console.error("Error in PlayerProvider useEffect:", err);
        }
        }, []);

    // Change Player Name

    // Update Player Resources
    const updateResource = (type, name, amount) => {
        setPlayer(prev => {
            if (!prev) return prev;
            
            const current = prev[type][name] || 0;
            const updated = Math.max(current + amount, 0);

            return {
                ...prev,
                [type]: {
                    ...prev[type],
                    [name]: updated
                }
            };
        });
        
    }

    // Update Player Skills

    //Update Player Equipment

    const value = {
        player,
        setPlayer,
        updateResource
    }

    return (
        <PlayerContext.Provider value={value}>
            {children}
        </PlayerContext.Provider>
    )
}