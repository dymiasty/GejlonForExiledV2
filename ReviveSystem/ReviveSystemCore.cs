using System.Collections.Generic;
using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace GejlonForExiledV2.ReviveSystem
{
    public class ReviveSystemCore
    {
        private EventHandlers Events;

        public Dictionary<Player, DeadPlayerData> deadPlayers = new Dictionary<Player, DeadPlayerData>();

        public void SubscribeEvents()
        {
            Events = new EventHandlers()
            {
                Core = Plugin.Instance.ReviveSystemCore
            };

            PlayerEvents.Died += Events.OnPlayerDied;
            PlayerEvents.Spawned += Events.OnPlayerSpawned;
            PlayerEvents.DroppedItem += Events.OnItemDropped;
        }

        public void UnsubscribeEvents()
        {
            PlayerEvents.Died -= Events.OnPlayerDied;
            PlayerEvents.Spawned -= Events.OnPlayerSpawned;
            PlayerEvents.DroppedItem -= Events.OnItemDropped;

            Events = null;
        }
    }
}
