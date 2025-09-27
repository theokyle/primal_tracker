import { capitalize } from "../../util/utility";
import { FaPlus } from "react-icons/fa";
import { FaMinus } from "react-icons/fa";



function ResourceItem({name, quantity}) {
    return (
        <li className="flex justify-between items-center bg-gray-100 rounded-lg p-3">
            <span>{capitalize(name)}</span>
            <div className="flex items-center space-x-2">
                <button className="p-1 bg-gray-400 text-white rounded hover:bg-gray-600">
                    <FaMinus />
                </button>
                <span>{quantity}</span>
                <button className="p-1 bg-gray-400 text-white rounded hover:bg-gray-600">
                    <FaPlus />
                </button>
            </div>
        </li>
    )
}

export default ResourceItem;