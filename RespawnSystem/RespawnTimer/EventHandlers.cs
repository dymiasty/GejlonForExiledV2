using Exiled.Events.EventArgs.Player;

namespace GejlonForExiledV2.RespawnSystem.RespawnTimer
{
    public class EventHandlers
    {
        public RespawnTimerCore Core;

        public void OnPlayerDied(DiedEventArgs ev)
        {
                Core.Spectators.Add(ev.Player);
        }

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (Core.Spectators.Contains(ev.Player))
            {
                Core.Spectators.Remove(ev.Player);
            }
        }

        public void OnWarheadDetonating(Exiled.Events.EventArgs.Warhead.DetonatingEventArgs ev)
        {
            Core.TimeLeft = 240;
        }
    }
}
