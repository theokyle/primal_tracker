import { createContext, useState } from 'react';

const PlayerContext = createContext();

export const PlayerProvider = ({children}) => {
    const [player, setPlayer] = useState(null);

    // UseEffect Hook to fetch data from DB

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
        <PlayerContext value={value}>
            {children}
        </PlayerContext>
    )
}