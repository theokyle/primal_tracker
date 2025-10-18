import Navbar from './components/layout/Navbar';
import { useState } from 'react';
import { Outlet } from 'react-router';
import { UserProvider } from './context/UserContext';

function App() {
  const [sideBarOpen, setSideBarOpen] = useState(false);

  return (
    <UserProvider>
      <div className="flex">
        <Navbar sideBarOpen={sideBarOpen} setSideBarOpen={setSideBarOpen}/>
        <Outlet setSideBarOpen={setSideBarOpen} />
      </div>
    </UserProvider>
  )
}

export default App
