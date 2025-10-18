import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from 'react-router'
import './index.css'
import App from './App.jsx'
import PlayerPage from './pages/PlayerPage.jsx'
import MainPage from './pages/MainPage.jsx'
import CampaignPage from './pages/CampaignPage.jsx'
import EncounterPage from './pages/EncounterPage.jsx'
import ProfilePage from './pages/ProfilePage.jsx'

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {index: true, element: <MainPage />},
      {path: "player", element: <PlayerPage />},
      {path: "campaign", element: <CampaignPage />},
      {path: "encounter", element: <EncounterPage />},
      {path: "profile", element: <ProfilePage />}
    ]
  }
])

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
