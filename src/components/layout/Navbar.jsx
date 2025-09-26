import { Link } from "react-router";
import { GiCrestedHelmet } from "react-icons/gi";
import { FaScroll } from "react-icons/fa";
import { GiSpikedDragonHead } from "react-icons/gi";
import { FaGear } from "react-icons/fa6";


export default function Navbar({sideBarOpen, setSideBarOpen}) {
const navItems = [
    {name: "Player", icon: <GiCrestedHelmet />, path: "player"},
    {name: "Campaign", icon: <FaScroll />, path: "campaign"},
    {name: "Encounter", icon: <GiSpikedDragonHead />, path:"encounter"},
    {name: "Settings", icon: <FaGear />, path:"settings"}
];

    return (
        <nav className={`fixed bg-white w-64 h-screen shadow ${sideBarOpen ? "translate-x-0" : "-translate-x-64"} lg:translate-x-0 lg:static`}>
            <div className="p-4 flex justify-between border-b">
                <Link to="/"><div className="text-xl font-bold"><img src="src/assets/primal_tracker_logo.png"></img></div></Link>
                <button className="lg:hidden" onClick={() => setSideBarOpen(false)}>X</button>
            </div>
            <div className="p-4 space-y-4">
                {navItems.map( item => {
                    return (
                        <div key={item.name}>
                            <Link to={item.path}>
                                <div className="flex p-3 hover:bg-gray-100 space-x-3">
                                    <div className="text-3xl">{item.icon}</div>
                                    <div className="text-xl">{item.name}</div>
                                </div>
                            </Link>
                        </div>
                    )
                })}
            </div>
        </nav>
    )
}