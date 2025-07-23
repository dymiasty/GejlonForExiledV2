using Exiled.API.Features;
using System.Collections.Generic;
using MEC;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace GejlonForExiledV2.RespawnSystem.RespawnTimer
{
    public class RespawnTimerCore
    {
        public int TimeLeft;

        public EventHandlers Events { get; private set; }

        public List<Player> Spectators { get; private set; } = new List<Player>();

        public void SubscribeEvents()
        {
            Events = new EventHandlers();

            Events.Core = Plugin.Instance.RespawnTimerCore;

            PlayerEvents.Died += Events.OnPlayerDied;
            PlayerEvents.Spawned += Events.OnPlayerSpawned;
        }

        public void UnsubscribeEvents()
        {
            PlayerEvents.Died -= Events.OnPlayerDied;
            PlayerEvents.Spawned -= Events.OnPlayerSpawned;

            Events.Core = null;

            Events = null;
        }

        public IEnumerator<float> CounterCoroutine()
        {
            while (TimeLeft > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                int minutes = TimeLeft / 60;
                int seconds = TimeLeft % 60;

                foreach (Player player in Spectators)
                {
                    if (minutes > 0)
                    {
                        player.ShowHint($"Respawn za:\n<color=#f8ff7a>{minutes}:{seconds:D2}</color>", 1.1f);
                    }
                    else
                    {
                        player.ShowHint($"Respawn za:\n<color=#f8ff7a>{seconds}</color> sekund", 1.1f);
                    }
                }

                TimeLeft--;
            }

            int spawnAnimationLength;

            if (Plugin.Instance.RespawnSystemCore.NineTailedFoxTokens > Plugin.Instance.RespawnSystemCore.ChaosTokens)
            {
                spawnAnimationLength = 12;
                while (spawnAnimationLength > 0)
                {
                    yield return Timing.WaitForSeconds(1f);
                    string messageToShow = "Trwa respawn <color=#0008ff>NTFu</color>.\n";
                    messageToShow += $"Respawn za: <color=#f8ff7a>{spawnAnimationLength}</color> sekund";

                    foreach (Player player in Spectators)
                        player.ShowHint(messageToShow, 1.1f);

                    spawnAnimationLength--;
                }
            }
            else
            {
                spawnAnimationLength = 9;
                while (spawnAnimationLength > 0)
                {
                    yield return Timing.WaitForSeconds(1f);
                    string messageToShow = "Trwa respawn <color=#145c20>CI</color>.\n";
                    messageToShow += $"Respawn za: <color=#f8ff7a>{spawnAnimationLength}</color> sekund";

                    foreach (Player player in Spectators)
                        player.ShowHint(messageToShow, 1.1f);

                    spawnAnimationLength--;
                }
            }
        }
    }
}
