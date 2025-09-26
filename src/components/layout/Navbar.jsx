import { GiCrestedHelmet } from "react-icons/gi";
import { FaScroll } from "react-icons/fa";
import { GiSpikedDragonHead } from "react-icons/gi";
import { FaGear } from "react-icons/fa6";


export default function Navbar({sideBarOpen, setSideBarOpen}) {
const navItems = [
    {name: "Player", icon: <GiCrestedHelmet />},
    {name: "Campaign", icon: <FaScroll />},
    {name: "Encounter", icon: <GiSpikedDragonHead />},
    {name: "Settings", icon: <FaGear />}
];

    return (
        <nav className={`fixed bg-white w-64 h-screen shadow ${sideBarOpen ? "translate-x-0" : "-translate-x-64"} lg:translate-x-0 lg:static`}>
            <div className="p-4 flex justify-between border-b">
                <div className="text-xl font-bold">Logo</div>
                <button className="lg:hidden" onClick={() => setSideBarOpen(false)}>X</button>
            </div>
            <div className="p-4 space-y-2">
                {navItems.map( item => {
                    return (
                        <div key={item.name} className="flex p-2 hover:bg-gray-100 space-x-3">
                            <div className="text-3xl">{item.icon}</div>
                            <div className="text-xl">{item.name}</div>
                            </div>
                    )
                })}
            </div>
        </nav>
    )
}