using PlayerEvents = Exiled.Events.Handlers.Player;

namespace GejlonForExiledV2.SCPLifesteal
{
    public class SCPLifestealCore
    {
        private EventHandlers Events;

        public void SubscribeEvents()
        {
            Events = new EventHandlers();

            PlayerEvents.Spawned += Events.OnPlayerSpawned;
            PlayerEvents.Hurt += Events.OnPlayerHurt;
        }

        public void UnsubscribeEvents()
        {
            PlayerEvents.Spawned -= Events.OnPlayerSpawned;
            PlayerEvents.Hurt -= Events.OnPlayerHurt;

            Events = null;
        }
    }
}
