using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using GejlonForExiledV2.CoinSystem;
using GejlonForExiledV2.CoinSystem.CoinPossibilities;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using PlayerRoles;

namespace GejlonForExiledV2.General
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Oczekiwanie na rozpoczęcie gry...");

            Round.IsLobbyLocked = true;
        }

        public void OnRoundStarted()
        {
            Room.Get(RoomType.Lcz914).Color = new Color(1f, 0f, 1f, 1f);

            Warhead.DeadmanSwitchEnabled = false;

            Timing.RunCoroutine(WarheadDetonateCoroutine());
            
            if (Player.List.ToList().Count == 8)
            {
                Timing.RunCoroutine(SCPSwap());
            }
        }

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (ev.Reason == SpawnReason.RoundStart)
                ev.Player.SendConsoleMessage(CoinSystemCore.CalculateChances(), "green");
        }

        public void OnPlayerShooting(ShootingEventArgs ev)
        {
            if (Random.Range(0, 2001) == 2000)
            {
                int ammoCount = ev.Firearm.MagazineAmmo;
                ev.Firearm.MagazineAmmo = 0;
                ev.Player.AddAmmo(ev.Firearm.AmmoType, (ushort)ammoCount);
                ev.Player.ShowHint("Twoja broń się zacięła!\nMusisz ją przeładować!", 6f);
            }
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Timing.RunCoroutine(RestartGameCoroutine());
        }

        private IEnumerator<float> WarheadDetonateCoroutine()
        {
            yield return Timing.WaitForSeconds(330);
            Plugin.Instance.CoinSystemCore.ValidCoinPossibilities.OfType<WarheadDetonate>().FirstOrDefault().CanDetonate = true;
        }

        private IEnumerator<float> RestartGameCoroutine()
        {
            yield return Timing.WaitForSeconds(7f);
            Server.Restart();
        }

        private IEnumerator<float> SCPSwap()
        {
            yield return Timing.WaitForSeconds(1.5f);
            List<Player> players = Util.GetLivingSCPs();
            Player player = players[Random.Range(0, 2)];

            foreach (Player p in players)
            {
                if (p.Role == RoleTypeId.Scp079)
                    player = p;
            }

            player.Role.Set(RoleTypeId.Scientist, SpawnReason.RoundStart, RoleSpawnFlags.All);
            player.ShowHint("Zmieniono cię z SCP w Naukowca\nze względu na ilość osób.");
        }
    }
}