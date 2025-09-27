import { useContext } from "react";
import ResourceItem from "./ResourceItem";
import { PlayerContext } from "../../context/PlayerContext";
import { capitalize } from "../../util/utility";

function ResourceCard({type}) {
    const { player, updateResource } = useContext(PlayerContext);

    if (!player) {
        return <p>Loading...</p>
    }
    return (
        <div className="bg-white p-6 shadow-lg rounded-lg w-full max-w-md mx-auto my-4">
            <h2 className="text-xl font-bold mb-5">{capitalize(type)}</h2>
            <ul className="space-y-2">
            {Object.entries(player[type]).map(([name, qty]) => 
            <ResourceItem 
                key={name} 
                name={name} 
                quantity={qty} 
                onIncrement={() => updateResource(type, name, 1)}
                onDecrement={() => updateResource(type, name, -1)}
                    />)}
            </ul>
          </div>
    )
}

export default ResourceCard;