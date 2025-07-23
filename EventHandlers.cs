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

namespace GejlonForExiledV2
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Oczekiwanie na rozpoczęcie gry...");

            Round.IsLobbyLocked = true;

            Plugin.Instance.BadLuckProtectionCore.LoadData();
        }

        public void OnRoundStarted()
        {
            Room.Get(RoomType.Lcz914).Color = new Color(1f, 0f, 1f, 1f);

            Warhead.DeadmanSwitchEnabled = false;

            Timing.RunCoroutine(_warheadDetonateCoroutine());
        }

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (ev.Reason == SpawnReason.RoundStart)
            {
                ev.Player.SendConsoleMessage(CoinSystemCore.CalculateChances(), "green");
            }
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

        private IEnumerator<float> _warheadDetonateCoroutine()
        {
            yield return Timing.WaitForSeconds(330);
            Plugin.Instance.CoinSystemCore.ValidCoinPossibilities.OfType<WarheadDetonate>().FirstOrDefault().CanDetonate = true;
        }

        private IEnumerator<float> RestartGameCoroutine()
        {
            yield return Timing.WaitForSeconds(7f);
            Server.Restart();
        }
    }
}