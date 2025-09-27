import { capitalize } from "../../util/utility";

function SkillItem({name, checked}) {
    return (
        <li className="flex justify-between items-center bg-gray-100 rounded-lg p-3">
            <span>{capitalize(name)}</span>
            <button className={`${checked ? "bg-black" : "bg-white"} p-4`}></button>
        </li>
    )
}

export default SkillItem;