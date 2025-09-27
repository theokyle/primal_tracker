import Topbar from '../components/layout/Topbar';
import PlayerDashboard from '../components/player/PlayerDashboard';
import { PlayerProvider } from '../context/PlayerContext';

function PlayerPage() {

  return (
    <PlayerProvider >
      <main className='flex-1 bg-gray-100'>
          <Topbar />
          <PlayerDashboard />
      </main>
    </PlayerProvider>
  )
}

export default PlayerPage