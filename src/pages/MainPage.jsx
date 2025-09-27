import Topbar from "../components/layout/Topbar"

function MainPage({setSideBarOpen}) {
    return (
    <main className='flex-1 h-screen'>
        <Topbar setSideBarOpen={setSideBarOpen} />
        <div className="bg-[url('https://reggiegames.com/cdn/shop/files/HOMEPAGE_Header.jpg?v=1725383782&width=1920')] bg-cover h-full -z-1 fixed bottom-0 w-screen flex flex-col items-center justify-center" >
            <div className="bg-gray-50/75 p-20 rounded-2xl">
                <h2 className="text-5xl font-bold mb-7 text-gray-800">Primal Campaign Tracker</h2>
                <p className="text-xl">A campaign manager for Primal: The Awakening by Reggie Games.</p>
            </div>
        </div>
    </main>
    )
}

export default MainPage