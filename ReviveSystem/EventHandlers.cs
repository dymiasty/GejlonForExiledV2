using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Player;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GejlonForExiledV2.ReviveSystem
{
    public class EventHandlers
    {
        public ReviveSystemCore Core;

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (Core.deadPlayers.ContainsKey(ev.Player))
                Core.deadPlayers.Remove(ev.Player);
        }

        public void OnPlayerDied(DiedEventArgs ev)
        {
            Core.deadPlayers.Add(ev.Player, new DeadPlayerData()
            {
                roleType = ev.Player.PreviousRole
            });

            List<Ragdoll> ragdolls = new List<Ragdoll>();

            foreach (Ragdoll ragdoll in Ragdoll.List.ToList())
            {
                if (ragdoll.Owner == ev.Player)
                {
                    ragdolls.Add(ragdoll);
                }
            }

            Ragdoll latestRagdoll = ragdolls[0];
            foreach (Ragdoll ragdoll in ragdolls)
            {
                if (ragdoll.ExistenceTime < latestRagdoll.ExistenceTime)
                    latestRagdoll = ragdoll;
            }

            Core.deadPlayers[ev.Player].LatestRagdoll = latestRagdoll;
        }

        public void OnItemDropped(DroppedItemEventArgs ev)
        {
            if (ev.Pickup.Type != ItemType.Medkit)
                return;

            Pickup medkit = ev.Pickup;
            Collider medkitCollider = medkit.Base.GetComponentInChildren<Collider>();

            _ = HandleMedkitLogicAsync(ev.Player, medkit, medkitCollider);
        }

        private async Task HandleMedkitLogicAsync(Player player, Pickup medkit, Collider medkitCollider)
        {
            try
            {
                var hitRagdoll = await GetRagdollOwnerAsync(medkitCollider, 2f, 0.1f);

                if (hitRagdoll == null)
                    return;

                if (RevivePlayer(hitRagdoll.Owner, player, hitRagdoll))
                    medkit.Destroy();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private async Task<Ragdoll> GetRagdollOwnerAsync(Collider medkitCollider, float duration, float interval)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                await Task.Delay(TimeSpan.FromSeconds(interval));

                foreach (Ragdoll ragdoll in Ragdoll.List.ToList())
                {
                    if (ragdoll == null || ragdoll.Base == null || ragdoll.Owner == null)
                        continue;

                    foreach (Collider ragdollCollider in ragdoll.Base.GetComponentsInChildren<Collider>().ToList())
                    {
                        if (ragdollCollider == null || medkitCollider == null)
                            continue;

                        if (ragdollCollider.bounds.Intersects(medkitCollider.bounds))
                        {
                            if (Core.deadPlayers.TryGetValue(ragdoll.Owner, out _))
                            {
                                return ragdoll;
                            }
                        }
                    }
                }

                elapsed += interval;
            }

            return null;
        }
        
        private bool RevivePlayer(Player playerToRevive, Player revivingPlayer, Ragdoll ragdoll)
        {
            if (ragdoll.Owner.IsScp)
                return false;

            if (ragdoll != Core.deadPlayers[playerToRevive].LatestRagdoll)
            {
                revivingPlayer.ShowHint("Już mu nie pomożesz.", 6f);
                return false;
            }

            Core.deadPlayers[playerToRevive].UsedMedkits++;

            if (Core.deadPlayers[playerToRevive].UsedMedkits == 2)
            {
                playerToRevive.Role.Set(Core.deadPlayers[playerToRevive].roleType, PlayerRoles.RoleSpawnFlags.None);
                ragdoll.Destroy();
                playerToRevive.Health /= 3f;
                playerToRevive.ShowHint("Zostałeś <color=#00ff2f>wskrzeszony</color> przez\n" +
                    $"gracza <color=#f8ff70>{revivingPlayer.Nickname}</color>.", 6f);

                revivingPlayer.ShowHint("Użyłeś apteczki aby\n" +
                    $"wskrzesić gracza {playerToRevive.Nickname}.", 6f);

                Log.Info($"{revivingPlayer.Nickname} wskrzesił {playerToRevive.Nickname}");
            }
            else
            {
                revivingPlayer.ShowHint("Użyłeś apteczki aby\n" +
                    $"wskrzesić gracza {playerToRevive.Nickname}.\n" +
                    $"Stan: <color=#f8ff70>1</color>/<color=#00ff2f>2</color>.", 6f);

                Log.Info($"{revivingPlayer.Nickname} wskrzesza {playerToRevive.Nickname} (1/2)");
            }

            return true;
        }
    }
}
