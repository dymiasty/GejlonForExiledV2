using Exiled.Events.EventArgs.Player;
using PlayerRoles;
namespace GejlonForExiledV2.RespawnSystem.RespawnTimer
{
    public class EventHandlers
    {
        public RespawnTimerCore Core;

        public void OnPlayerDied(DiedEventArgs ev)
        {
            if (!ev.Player.IsNPC && ev.Player.Role != RoleTypeId.Overwatch)
            {
                Core.Spectators.Add(ev.Player);
            }
        }

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (Core.Spectators.Contains(ev.Player))
            {
                Core.Spectators.Remove(ev.Player);
            }
        }
    }
}
