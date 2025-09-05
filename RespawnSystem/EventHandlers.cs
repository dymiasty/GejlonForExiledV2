using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using MEC;
using Exiled.API.Enums;
using Player = Exiled.API.Features.Player;
using Exiled.Events.EventArgs.Server;
using UnityEngine;
using Exiled.API.Extensions;
using GejlonForExiledV2.RespawnSystem.RespawnTimer;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.RespawnSystem
{
    internal class EventHandlers
    {
        public RespawnSystemCore Core;

        public RespawnTimerCore Timer;

        private readonly Dictionary<Player, bool> _civilliansReachedHeavy = new Dictionary<Player, bool>();
        private readonly Dictionary<Player, bool> _civilliansReachedEntrance = new Dictionary<Player, bool>();
        private readonly Dictionary<Player, bool> _civilliansReachedSurface = new Dictionary<Player, bool>();

        private bool _microHIDpickedUp = false;
        private bool _scp244aUsed = false;
        private bool _scp244bUsed = false;
        private bool _scp268Used = false;
        private bool _warheadUnlocked = false;

        private Team _warheadStartedBy;

        public void OnRoundStarted()
        {
            Core.NineTailedFoxTokens = 57.714285f;
            Core.ChaosTokens = 42.85715f;
        }

        public void OnItemPickedUp(ItemAddedEventArgs ev)
        {
            // First MicroHID Pickup
            if (ev.Item.Type == ItemType.MicroHID && _microHIDpickedUp == false)
            {
                _microHIDpickedUp = true;
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(1f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(1f);
                    return;
                }
            }

            // Firearms
            if (ev.Item.Category == ItemCategory.Firearm)
            {
                if (ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.4f);
                    return;
                }
                else if (ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.4f);
                    return;
                }
            }
        }

        public void OnItemDropped(ItemRemovedEventArgs ev)
        {
            // Firearms
            if (ev.Item.Category == ItemCategory.Firearm)
            {
                if (ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddNineTailedFoxTokens(0.4f);
                    return;
                }
                else if (ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddChaosTokens(0.4f);
                    return;
                }
            }
        }

        public void OnItemUsed(UsedItemEventArgs ev)
        {
            // SCP018 - ball
            if (ev.Item.Type == ItemType.SCP018)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(1f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(1f);
                    return;
                }
            }

            // SCP268 - czapka
            if (ev.Item.Type == ItemType.SCP268 && _scp268Used == false)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    _scp268Used = true;
                    Core.AddNineTailedFoxTokens(1f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    _scp268Used = true;
                    Core.AddChaosTokens(1f);
                    return;
                }
            }

            // SCP207 - cola
            if (ev.Item.Type == ItemType.SCP207)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.7f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.7f);
                    return;
                }
            }

            // SCP244A - okrągły dzbanek
            if (ev.Item.Type == ItemType.SCP244a && _scp244aUsed == false)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    _scp244aUsed = true;
                    Core.AddNineTailedFoxTokens(0.7f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    _scp244aUsed = true;
                    Core.AddChaosTokens(0.7f);
                    return;
                }
            }

            // SCP244B - pionowy dzbanek
            if (ev.Item.Type == ItemType.SCP244b && _scp244bUsed == false)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    _scp244bUsed = true;
                    Core.AddNineTailedFoxTokens(0.7f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    _scp244bUsed = true;
                    Core.AddChaosTokens(0.7f);
                    return;
                }
            }

            // SCP1853 - zielone od broni
            if (ev.Item.Type == ItemType.SCP1853)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.7f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.7f);
                    return;
                }
            }

            // SCP2176 - żarówka
            if (ev.Item.Type == ItemType.SCP2176)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.7f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.7f);
                    return;
                }
            }

            // SCP500
            if (ev.Item.Type == ItemType.SCP500)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.4f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.4f);
                    return;
                }
            }

            // SCP330 - cukierki
            if (ev.Item.Type == ItemType.SCP330)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.1f);
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.1f);
                    return;
                }
            }
        }

        public void OnPlayerShot(ShotEventArgs ev)
        {
            if (ev.Target == null) return;

            // Hurting SCPs
            if (ev.Target.IsScp && ev.Target.Role != RoleTypeId.Scp0492)
            {
                // Hume
                if (ev.Target.HumeShield > 0)
                {
                    // NTF
                    if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddNineTailedFoxTokens(0.0005f * ev.Damage * 0.75f);
                        return;
                    }
                    // Chaos
                    else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                    {
                        Core.AddChaosTokens(0.0005f * ev.Damage * 0.75f);
                        return;
                    }
                }
                // No Hume
                else
                {
                    // NTF
                    if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddNineTailedFoxTokens(ev.Damage/ev.Target.MaxHealth * 100f * 0.4f * 0.1f);
                        return;
                    }
                    // Chaos
                    else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                    {
                        Core.AddChaosTokens(ev.Damage / ev.Target.MaxHealth * 100f * 0.4f * 0.1f);
                        return;
                    }
                }
            }
        }

        public void OnSelectingRespawnTeam(SelectingRespawnTeamEventArgs ev)
        {
            ev.IsAllowed = false;
        }

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (ev.Reason == SpawnReason.RoundStart)
                if (ev.Player.Role == RoleTypeId.ClassD || ev.Player.Role == RoleTypeId.Scientist)
                {
                    _civilliansReachedHeavy.Add(ev.Player, false);
                    _civilliansReachedEntrance.Add(ev.Player, false);
                    _civilliansReachedSurface.Add(ev.Player, false);
                }
        }

        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (!Core.MainCountdownStarted && !Core.IsRespawning)
            {
                int spawnDelay = Random.Range(280, 351);
                Timer.TimeLeft = spawnDelay;

                Timing.RunCoroutine(Core.EnqueueSpawn(spawnDelay), "mainRespawn");
                Timing.RunCoroutine(Timer.CounterCoroutine(), "respawnTimer");

                Core.MainCountdownStarted = true;
            }

            if (ev.Attacker == null || ev.Attacker == ev.Player)
            {
                // Chaos dying from "other means"
                if (ev.Player.IsCHI)
                    if (Core.WavesAmount == 0)
                    {
                        Core.AddNineTailedFoxTokens(1.2f);
                        return;
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(1.2f * Core.WavesAmount);
                        return;
                    }

                // NTF dying from "other means"
                if (ev.Player.IsNTF || ev.Player.Role == RoleTypeId.FacilityGuard)
                    if (Core.WavesAmount == 0)
                    {
                        Core.AddChaosTokens(1.2f);
                        return;
                    }
                    else
                    {
                        Core.AddChaosTokens(1.2f * Core.WavesAmount);
                        return;
                    }
                
                return;
            }

            // SCP Termination
            if (ev.Player.IsScp && ev.Player.Role != RoleTypeId.Scp0492)
            {
                if (ev.Attacker.Role.Team == Team.FoundationForces || ev.Attacker.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(3f);
                    if (ev.Attacker.CurrentItem.Type == ItemType.MicroHID)
                    {
                        Core.AddNineTailedFoxTokens(1.5f);
                    }
                    return;
                }
                else if (ev.Attacker.Role.Team == Team.ChaosInsurgency || ev.Attacker.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(3f);
                    if (ev.Attacker.CurrentItem.Type == ItemType.MicroHID)
                    {
                        Core.AddChaosTokens(1.5f);
                    }
                    return;
                }
            }

            // NTF killing Chaos
            if (ev.Attacker.IsNTF || ev.Attacker.Role == RoleTypeId.FacilityGuard)
                if (ev.Player.IsCHI)
                {
                    Core.AddNineTailedFoxTokens(1.5f);

                    return;
                }

            // Guard killing Class D
            if (ev.Attacker.Role == RoleTypeId.FacilityGuard)
            {
                bool isTargetArmed = false;

                foreach (Item item in ev.Player.Items.ToList())
                {
                    if (item.IsWeapon || item.Type == ItemType.GunSCP127 || item.Type == ItemType.ParticleDisruptor)
                    {
                        isTargetArmed = true;
                        break;
                    }
                }

                if (isTargetArmed)
                {
                    Core.AddNineTailedFoxTokens(0.5f);
                    return;
                }
            }

            // Class D killing NTF
            if (ev.Attacker.Role == RoleTypeId.ClassD)
                if (ev.Player.IsNTF || ev.Player.Role == RoleTypeId.FacilityGuard)
                {
                    Core.AddChaosTokens(2f);
                    return;
                }

            // Class D or Chaos killing Scientist
            if (ev.Attacker.IsCHI || ev.Attacker.Role == RoleTypeId.ClassD)
                if (ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddChaosTokens(1.4f);
                    return;
                }

            // Chaos killing NTF or Guard
            if (ev.Attacker.IsCHI)
                if (ev.Player.IsNTF || ev.Player.Role == RoleTypeId.FacilityGuard)
                {
                    Core.AddChaosTokens(1.5f);
                    return;
                }
        }

        public void OnPlayerEscaping(EscapingEventArgs ev)
        {
            // Scientist escaping
            if (ev.Player.Role == RoleTypeId.Scientist)
            {
                Core.AddNineTailedFoxTokens(3f);
                return;
            }

            // Cuffed Class D escaping
            if (ev.Player.Role == RoleTypeId.ClassD && ev.Player.IsCuffed)
            {
                Core.AddNineTailedFoxTokens(3f);
                return;
            }

            // Class D escaping
            if (ev.Player.Role == RoleTypeId.ClassD)
            {
                Core.AddChaosTokens(4f);
                return;
            }
            
            // Cuffed Scientist escaping
            if (ev.Player.Role == RoleTypeId.Scientist && ev.Player.IsCuffed)
            {
                Core.AddChaosTokens(4f);
                return;
            }
        }

        public void OnGeneratorUnlocked(UnlockingGeneratorEventArgs ev)
        {
            bool canOpen = false;

            if (ev.Player.CurrentItem !=  null && !ev.Generator.IsUnlocked)
            {
                if (ev.Player.CurrentItem.Type == ItemType.KeycardMTFCaptain)
                    canOpen = true;
                else if (ev.Player.CurrentItem.Type == ItemType.KeycardMTFOperative)
                    canOpen = true;
                else if (ev.Player.CurrentItem.Type == ItemType.KeycardMTFPrivate)
                    canOpen = true;
                else if (ev.Player.CurrentItem.Type == ItemType.KeycardO5)
                    canOpen = true;
            }

            if (canOpen)
            {
                Core.AddNineTailedFoxTokens(0.5f);
            }
        }

        public void OnGeneratorEngaged(GeneratorActivatingEventArgs ev)
        {
            Core.AddNineTailedFoxTokens(1f);
            return;
        }

        public void OnPlayerMoveStateChange(ChangingMoveStateEventArgs ev)
        {
            // is a player civillian?
            if (!_civilliansReachedHeavy.ContainsKey(ev.Player))
                return;

            // civillian reaching HCZ
            if (ev.Player.Zone == ZoneType.HeavyContainment)
            {
                if (ev.Player.Role == RoleTypeId.Scientist || ev.Player.Role == RoleTypeId.ClassD)
                    if (_civilliansReachedHeavy.TryGetValue(ev.Player, out bool value) && value == false)
                    {
                        _civilliansReachedHeavy[ev.Player] = true;
                        Timing.RunCoroutine(HeavyCheckCoroutine(ev.Player), "zoneCheck");
                    }
            }

            // civillian reaching EZ
            if (ev.Player.Zone == ZoneType.Entrance)
            {
                if (ev.Player.Role == RoleTypeId.Scientist || ev.Player.Role == RoleTypeId.ClassD)
                    if (_civilliansReachedEntrance.TryGetValue(ev.Player, out bool value) && value == false)
                    {
                        _civilliansReachedEntrance[ev.Player] = true;
                        Timing.RunCoroutine(EntranceCheckCoroutine(ev.Player), "zoneCheck");
                    }
            }

            // civillian reaching Surface
            if (ev.Player.Zone == ZoneType.Surface)
            {
                if (ev.Player.Role == RoleTypeId.Scientist || ev.Player.Role == RoleTypeId.ClassD)
                    if (_civilliansReachedSurface.TryGetValue(ev.Player, out bool value) && value == false)
                    {
                        _civilliansReachedSurface[ev.Player] = true;
                        Timing.RunCoroutine(SurfaceCheckCoroutine(ev.Player), "zoneCheck");
                    }
            }
        }

        public void OnWarheadUnlock(ActivatingWarheadPanelEventArgs ev)
        {
            if (_warheadUnlocked)
                return;

            if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
            {
                Core.AddNineTailedFoxTokens(1f);
                _warheadUnlocked = true;
                return;
            }
            else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
            {
                Core.AddChaosTokens(1f);
                _warheadUnlocked = true;
                return;
            }
        }

        public void OnWarheadStarting(Exiled.Events.EventArgs.Warhead.StartingEventArgs ev)
        {
            _warheadStartedBy = ev.Player.Role.Team;
        }

        public void OnWarheadDetonating(Exiled.Events.EventArgs.Warhead.DetonatingEventArgs ev)
        {
            Timing.KillCoroutines("mainRespawn");
            Timing.RunCoroutine(Core.EnqueueSpawn(240f));

            if (_warheadStartedBy == Team.FoundationForces || _warheadStartedBy == Team.Scientists)
            {
                foreach (Player player in Player.List.ToList())
                {
                    if (player.Role == RoleTypeId.Scientist && player.Zone != ZoneType.Surface)
                        return;
                }

                Core.AddNineTailedFoxTokens(6f);
                return;
            }
            else if (_warheadStartedBy == Team.ChaosInsurgency || _warheadStartedBy == Team.ClassD)
            {
                foreach (Player player in Player.List.ToList())
                {
                    if (player.Role == RoleTypeId.ClassD && player.Zone != ZoneType.Surface)
                        return;
                }

                Core.AddChaosTokens(6f);
                return;
            }
        }

        public void OnRespawnWave(RespawnedTeamEventArgs ev)
        {
            Core.MainCountdownStarted = false;

            List<Player> respawnedPlayers = new List<Player>();

            respawnedPlayers.AddRange(ev.Players);

            foreach (Player player in Player.List.ToList())
            {
                if (player.Role == RoleTypeId.Spectator)
                {
                    // making sure everyone spawns
                    if (ev.Wave.TargetFaction == Faction.FoundationStaff)
                    {
                        player.Role.Set(RoleTypeId.NtfPrivate, SpawnReason.Respawn, RoleSpawnFlags.All);
                    }
                    else if (ev.Wave.TargetFaction == Faction.FoundationEnemy)
                    {
                        player.Role.Set(RoleTypeId.ChaosRifleman, SpawnReason.Respawn, RoleSpawnFlags.All);
                    }
                    
                    respawnedPlayers.Add(player);
                }
            }

            // ci spy
            if (Random.Range(1, 101) > 95)
            {
                Player ciSpy = respawnedPlayers[Random.Range(0, respawnedPlayers.Count)];

                byte previousUnitId = ciSpy.UnitId;

                ciSpy.Role.Set(RoleTypeId.ChaosConscript, SpawnReason.Respawn, RoleSpawnFlags.None);
                ciSpy.ChangeAppearance(ciSpy.PreviousRole, true, previousUnitId);

                Exiled.API.Features.Broadcast broadcast = new Exiled.API.Features.Broadcast
                {
                    Duration = 15,
                    Show = true,
                    Type = Broadcast.BroadcastFlags.Normal,
                    Content = "Jesteś <color=green>Szpiegiem Rebelii Chaosu</color>.\n" +
                        "Inni gracze widzą cię jakbyś był z oddziału NTF, obowiązują cię\n" +
                        "standardowe warunki wygranej Rebelii Chaosu."
                };

                ciSpy.Broadcast(broadcast, true);
            }


            if (ev.Wave.TargetFaction == Faction.FoundationStaff)
                Core.AddNineTailedFoxTokens(respawnedPlayers.Count);
            else if (ev.Wave.TargetFaction == Faction.FoundationEnemy)
                Core.AddChaosTokens(respawnedPlayers.Count);
        }

        private IEnumerator<float> HeavyCheckCoroutine(Player player)
        {
            yield return Timing.WaitForSeconds(10f);
            if (player.Zone == ZoneType.HeavyContainment)
            {
                if (!player.IsCuffed)
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddNineTailedFoxTokens(0.1f);
                    }
                    else
                    {
                        Core.AddChaosTokens(0.1f);
                    }
                }
                else
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddChaosTokens(0.1f);
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(0.1f);
                    }
                }
            }
            else
            {
                _civilliansReachedHeavy[player] = false;
            }
        }

        private IEnumerator<float> EntranceCheckCoroutine(Player player)
        {
            yield return Timing.WaitForSeconds(10f);
            if (player.Zone == ZoneType.Entrance)
            {
                if (!player.IsCuffed)
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddNineTailedFoxTokens(0.15f);
                    }
                    else
                    {
                        Core.AddChaosTokens(0.15f);
                    }
                }
                else
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddChaosTokens(0.15f);
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(0.15f);
                    }
                }
            }
            else
            {
                _civilliansReachedEntrance[player] = false;
            }
        }

        private IEnumerator<float> SurfaceCheckCoroutine(Player player)
        {
            yield return Timing.WaitForSeconds(10f);
            if (player.Zone == ZoneType.Surface)
            {
                if (!player.IsCuffed)
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddNineTailedFoxTokens(0.2f);
                    }
                    else
                    {
                        Core.AddChaosTokens(0.2f);
                    }
                }
                else
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddChaosTokens(0.2f);
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(0.2f);
                    }
                }
            }
            else
            {
                _civilliansReachedSurface[player] = false;
            }
        }
    }
}
