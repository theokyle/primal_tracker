import Topbar from './components/layout/Topbar';
import Navbar from './components/layout/Navbar';
import { useState } from 'react';
import { Outlet } from 'react-router';

function App() {
  const [sideBarOpen, setSideBarOpen] = useState(false);

  return (
    <div className="flex">
      <Navbar sideBarOpen={sideBarOpen} setSideBarOpen={setSideBarOpen}/>
      <Outlet setSideBarOpen={setSideBarOpen} />
    </div>
  )
}

export default App
