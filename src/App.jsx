import Topbar from './components/layout/Topbar';
import Navbar from './components/layout/Navbar';
import { useState } from 'react';

function App() {
  const [sideBarOpen, setSideBarOpen] = useState(false);

  return (
    <div className="flex bg-gray-100 h-screen">
      <Navbar sideBarOpen={sideBarOpen} setSideBarOpen={setSideBarOpen}/>
      <main className='flex-1'>
        <Topbar setSideBarOpen={setSideBarOpen} />
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 p-4 gap-4">
          {/* Sample Card */}
          <div className="bg-white p-6 shadow-lg rounded-lg">
            <h2 className="text-xl font-bold">Card</h2>
            <p className="text-lg p-1 text-gray-700">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. In libero tortor, tempus non enim at, euismod tristique odio. Phasellus placerat magna eget viverra pellentesque.
            </p>
          </div>
        </div>
      </main>
    </div>
  )
}

export default App
