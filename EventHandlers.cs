﻿using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Random = UnityEngine.Random;
using GejlonForExiledV2.CoinPossibilities;
using System.Linq;
using PlayerRoles;
using Exiled.API.Enums;
using UnityEngine;

namespace GejlonForExiledV2
{
    public class EventHandlers
    {
        public bool armageddonOn = false;

        public void OnWaitingForPlayers()
        {
            Log.Info("Oczekiwanie na rozpoczęcie gry...");

            Round.IsLobbyLocked = true;
        }

        public void OnRoundStarted()
        {
            // armageddon
            if (Random.Range(0, 101) >= 95) armageddonOn = true;

            if (armageddonOn)
                Map.Broadcast(5, "W tej rundzie <i>będzie <color=red>armagedon</i></color>", Broadcast.BroadcastFlags.Normal, true);

            foreach (Player player in Player.List)
            {
                if (!player.IsNPC && !player.IsScp && !player.IsDead && !player.IsInventoryFull && Random.Range(0, 101) >= 50)
                {
                    // free coin on the beggining
                    player.AddItem(ItemType.Coin);
                    player.Broadcast(5, "Dostałeś bonusową monetkę na start.");
                }

                if (armageddonOn)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (player.IsInventoryFull)
                        {
                            Item coin = Item.Create(ItemType.Coin);
                            coin.CreatePickup(player.Position);
                        }
                        else
                            player.AddItem(ItemType.Coin);
                    }
                }
            }

            Room.Get(RoomType.Lcz914).Color = new Color(1f, 0f, 1f, 1f);

            Warhead.DeadmanSwitchEnabled = false;
        }

        public void OnPlayerCoinFlipping(FlippingCoinEventArgs ev)
        {
            int tickets = Random.Range(0, 101);

            if (armageddonOn) tickets = 100;

            bool canExecute;
            int wynik = Random.Range(0, Plugin.Instance.CoinMachine.CoinPossibilityTypes.Count);
            CoinPossibility possibility = Plugin.Instance.CoinMachine.GetPossibility(wynik);
            Log.Info(ev.Player.Nickname + " rzucił monetą i trafił " + possibility.Id);

            ev.Player.RemoveHeldItem();

            canExecute = possibility.CanExecute(ev.Player);

            if (tickets < possibility.RequiredTickets)
                canExecute = false;

            if (!canExecute)
            {
                ev.Player.ShowHint("Nic się nie stało...", 6f);
                return;
            }

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
    }
}