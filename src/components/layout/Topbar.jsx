import { GiHamburgerMenu } from "react-icons/gi";

export default function Topbar({setSideBarOpen}) {

    return (
        <header className="bg-white flex justify-between p-4">
            <button className="p-2 text-x1 font-bold lg:hidden" onClick={() => setSideBarOpen(true)}><GiHamburgerMenu />
</button>
            <h1 className="text-2xl font-bold">Dashboard</h1>
            <div className="bg-gray-300 w-10 h-10 rounded-full"></div>
        </header>
    )
}