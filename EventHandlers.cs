using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Random = UnityEngine.Random;
using GejlonForExiledV2.CoinPossibilities;
using System.Linq;
using PlayerRoles;
using Exiled.API.Enums;
using UnityEngine;
using System;

namespace GejlonForExiledV2
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Oczekiwanie na rozpoczęcie gry...");

            Round.IsLobbyLocked = true;

            Log.Info(CalculateChances());
        }

        public void OnRoundStarted()
        {
            Room.Get(RoomType.Lcz914).Color = new Color(1f, 0f, 1f, 1f);

            Warhead.DeadmanSwitchEnabled = false;
        }

        public void OnPlayerCoinFlipping(FlippingCoinEventArgs ev)
        {
            bool canExecute;

            int wynik = Random.Range(0, Plugin.Instance.CoinSystemCore.ValidCoinPossibilities.Count);
            CoinPossibility possibility = Plugin.Instance.CoinSystemCore.GetPossibility(wynik);

            canExecute = possibility.CanExecute(ev.Player);
            
            while (!canExecute)
            {
                Log.Info($"Gracz {ev.Player.Nickname} wylosował {possibility.Id} ale nie mogło się wykonać.");

                wynik = Random.Range(0, Plugin.Instance.CoinSystemCore.ValidCoinPossibilities.Count);
                possibility = Plugin.Instance.CoinSystemCore.GetPossibility(wynik);

                canExecute = possibility.CanExecute(ev.Player);
            }

            Log.Info(ev.Player.Nickname + " rzucił monetą i trafił " + possibility.Id);

            ev.Player.RemoveHeldItem();

            possibility.Execute(ev.Player);
            ev.Player.ShowHint(possibility.Hint, possibility.HintDuration);

            return;
        }

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (ev.Player.Role == RoleTypeId.Scientist && ev.Reason != SpawnReason.ItemUsage)
            {
                int O5chance = 95;

                if (Random.Range(0, 101) > O5chance)
                {
                    foreach (Item item in ev.Player.Items.ToList())
                    {
                        if (item.Type != ItemType.Coin)
                        {
                            ev.Player.RemoveItem(item);
                        }
                    }

                    ev.Player.AddItem(ItemType.GunCOM15);
                    ev.Player.AddAmmo(AmmoType.Nato9, 24);
                    ev.Player.AddItem(ItemType.KeycardO5);
                    ev.Player.AddItem(ItemType.SCP500);

                    ev.Player.ShowHint("Jesteś członkiem <color=#323633>Rady O5</color>.\n-Zaczynasz grę z lepszymi przedmiotami.", 6f);
                }
            }

            if (ev.Player.Role == RoleTypeId.ClassD && ev.Reason != SpawnReason.ItemUsage)
            {
                int smugglerNegativeChance = 95;

                if (Random.Range(0, 101) > smugglerNegativeChance)
                {
                    foreach (Item item in ev.Player.Items)
                    {
                        if (item.Type != ItemType.Coin)
                        {
                            ev.Player.RemoveItem(item);
                        }
                    }

                    ev.Player.AddItem(ItemType.GunCOM15);
                    ev.Player.AddAmmo(AmmoType.Nato9, 6);
                    ev.Player.AddItem(ItemType.KeycardScientist);
                    ev.Player.AddItem(ItemType.KeycardZoneManager);
                    ev.Player.AddItem(ItemType.Painkillers);

                    ev.Player.ShowHint("Jesteś <color=#38634a>Przemytnikiem</color>.\n-Zaczynasz grę z przyzwoitymi przedmiotami.", 6f);
                }
            }

            if (ev.Reason == SpawnReason.RoundStart)
            {
                ev.Player.SendConsoleMessage(CalculateChances(), "green");
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

        public void OnCompletedUsingItem(UsingItemCompletedEventArgs ev)
        {
            if (ev.Item.Type.Equals(ItemType.SCP500) && ev.Player.IsNTF)
            {
                if (Random.Range(0, 101) > 50)
                {
                    ev.Player.Role.Set(RoleTypeId.ChaosRifleman, SpawnReason.ItemUsage, RoleSpawnFlags.None);
                    ev.Player.ShowHint("Czujesz nagłą potrzebę zdradzenia swoich sojuszników.", 6f);
                }
            }
        }


        private string CalculateChances()
        {
            float weightSum = 0;
            foreach (CoinPossibility possibility in Plugin.Instance.CoinSystemCore.ValidCoinPossibilities)
            {
                weightSum += possibility.Weight;
            }

            string chances = "Lista szans wszystkich dostępnych opcji monet:\n";
            foreach (CoinPossibility possibility in Plugin.Instance.CoinSystemCore.ValidCoinPossibilities)
            {
                chances += $"{possibility.Id} - (~{Math.Round(((float)possibility.Weight / weightSum) * 100f, 2)}%)\n";
            }

            return chances;
        }
    }
}