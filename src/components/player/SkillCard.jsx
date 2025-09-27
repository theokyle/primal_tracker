import SkillItem from "./SkillItem";
import { useContext } from "react";
import { PlayerContext } from "../../context/PlayerContext";

function SkillCard() {
    const { player } = useContext(PlayerContext);

    if (!player) {
        return <p>Loading...</p>
    }
    return (
        <div className="bg-white p-6 shadow-lg rounded-lg w-full max-w-md mx-auto my-4">
            <h2 className="text-xl font-bold mb-5">Skill Tree</h2>
            <ul className="grid grid-cols-2 gap-2">
            {Object.entries(player.skills).map(([name, checked]) => <SkillItem key={name} name={name} checked={checked} />)}
            </ul>
          </div>
    )
}

export default SkillCard;