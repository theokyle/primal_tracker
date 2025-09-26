import Topbar from '../components/layout/Topbar';
import PlayerDashboard from '../components/player/PlayerDashboard';

function PlayerPage() {

  return (
    <main className='flex-1 bg-gray-100'>
        <Topbar />
        <PlayerDashboard />
    </main>
  )
}

export default PlayerPage