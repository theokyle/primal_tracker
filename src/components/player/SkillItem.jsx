import { capitalize } from "../../util/utility";
import { useContext } from "react";
import { PlayerContext } from "../../context/PlayerContext";

function SkillItem({name, checked}) {
    const { updateSkill } = useContext(PlayerContext);
    return (
        <li className="flex justify-between items-center bg-gray-100 rounded-lg p-3">
            <span>{capitalize(name)}</span>
            <button className={`${checked ? "bg-black" : "bg-white"} p-4`} onClick={() => updateSkill(name)}></button>
        </li>
    )
}

export default SkillItem;