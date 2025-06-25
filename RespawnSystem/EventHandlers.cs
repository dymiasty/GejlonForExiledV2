using Exiled.API.Features;
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
using JetBrains.Annotations;

namespace GejlonForExiledV2.RespawnSystem
{
    internal class EventHandlers
    {
        private RespawnSystemCore Core;

        private Dictionary<Player, bool> _civilliansReachedHeavy = new Dictionary<Player, bool>();
        private Dictionary<Player, bool> _civilliansReachedEntrance = new Dictionary<Player, bool>();
        private Dictionary<Player, bool> _civilliansReachedSurface = new Dictionary<Player, bool>();

        private bool _microHIDpickedUp = false;
        private bool _scp244aUsed = false;
        private bool _scp244bUsed = false;
        private bool _scp268Used = false;

        private Team _warheadStartedBy;

        public void OnRoundStarted()
        {
            Core = Plugin.Instance.RespawnSystemCore;

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
                    Log.Info("NTF pierwszy podniósł MicroHIDa - NTF +1");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(1f);
                    Log.Info("Chaos pierwszy podniósł MicroHIDa - Chaos +1");
                    Core.LogTickets();
                    return;
                }
            }

            // Firearms
            if (ev.Item.Category == ItemCategory.Firearm)
            {
                if (ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.4f);
                    Log.Info("Klasa D podniosła broń - Chaos +0.4");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.4f);
                    Log.Info("Naukowiec podniósł broń - NTF +0.4");
                    Core.LogTickets();
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
                    Log.Info("Klasa D upuściła broń - NTF +0.4");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddChaosTokens(0.4f);
                    Log.Info("Naukowiec upuścił broń - Chaos +0.4");
                    Core.LogTickets();
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
                    Log.Info("NTF użył SCP018 - NTF +1");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(1f);
                    Log.Info("Chaos użył SCP018 - Chaos +1");
                    Core.LogTickets();
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
                    Log.Info("NTF użył SCP268 - NTF +1");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    _scp268Used = true;
                    Core.AddChaosTokens(1f);
                    Log.Info("Chaos użył SCP268 - Chaos +1");
                    Core.LogTickets();
                    return;
                }
            }

            // SCP207 - cola
            if (ev.Item.Type == ItemType.SCP207)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.7f);
                    Log.Info("NTF użył SCP207 - NTF +0.7");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.7f);
                    Log.Info("Chaos użył SCP207 - Chaos +0.7");
                    Core.LogTickets();
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
                    Log.Info("NTF użył SCP244A - NTF +1");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    _scp244aUsed = true;
                    Core.AddChaosTokens(0.7f);
                    Log.Info("Chaos użył SCP244A - Chaos +1");
                    Core.LogTickets();
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
                    Log.Info("NTF użył SCP244B - NTF +1");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    _scp244bUsed = true;
                    Core.AddChaosTokens(0.7f);
                    Log.Info("Chaos użył SCP244B - Chaos +1");
                    Core.LogTickets();
                    return;
                }
            }

            // SCP1853 - zielone od broni
            if (ev.Item.Type == ItemType.SCP1853)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.7f);
                    Log.Info("NTF użył SCP1853 - NTF +0.7");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.7f);
                    Log.Info("Chaos użył SCP1853 - Chaos +0.7");
                    Core.LogTickets();
                    return;
                }
            }

            // SCP2176 - żarówka
            if (ev.Item.Type == ItemType.SCP2176)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.7f);
                    Log.Info("NTF użył SCP2176 - NTF +0.7");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.7f);
                    Log.Info("Chaos użył SCP2176 - Chaos +0.7");
                    Core.LogTickets();
                    return;
                }
            }

            // SCP500
            if (ev.Item.Type == ItemType.SCP500)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.4f);
                    Log.Info("NTF użył SCP500 - NTF +0.4");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.4f);
                    Log.Info("Chaos użył SCP500 - Chaos +0.4");
                    Core.LogTickets();
                    return;
                }
            }

            // SCP330 - cukierki
            if (ev.Item.Type == ItemType.SCP330)
            {
                if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddNineTailedFoxTokens(0.1f);
                    Log.Info("NTF użył SCP330 - NTF +0.1");
                    Core.LogTickets();
                    return;
                }
                else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(0.1f);
                    Log.Info("Chaos użył SCP207 - Chaos +0.1");
                    Core.LogTickets();
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
                        Core.AddNineTailedFoxTokens(0.0005f * ev.Damage);
                        Log.Info("NTF zadał obrażenia SCP - NTF +");
                        Core.LogTickets();
                        return;
                    }
                    // Chaos
                    else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                    {
                        Core.AddChaosTokens(0.0005f * ev.Damage);
                        Log.Info("Chaos zadał obrażenia SCP - Chaos +");
                        Core.LogTickets();
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
                        Log.Info("NTF zadał obrażenia SCP - NTF +");
                        Core.LogTickets();
                        return;
                    }
                    // Chaos
                    else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
                    {
                        Core.AddChaosTokens(ev.Damage / ev.Target.MaxHealth * 100f * 0.4f * 0.1f);
                        Log.Info("Chaos zadał obrażenia SCP - Chaos +");
                        Core.LogTickets();
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
                    Log.Info($"Dodano gracza {ev.Player.Nickname} do słowników od stref.");
                }
        }

        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (Core.MainCountdownStarted == false)
            {
                Timing.RunCoroutine(Core.EnqueueSpawn(Random.Range(280f, 350f)), "mainRespawn");
                Log.Info("Wystartowano główny timer respawnu.");
                Core.MainCountdownStarted = true;
            }

            if (ev.Attacker == null || ev.Attacker == ev.Player)
            {
                // Chaos dying from "other means"
                if (ev.Player.IsCHI)
                    if (Core.WavesAmount == 0)
                    {
                        Core.AddNineTailedFoxTokens(1.2f);
                        Log.Info("CI umarł - NTF +1.2");
                        Core.LogTickets();
                        return;
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(1.2f * Core.WavesAmount);
                        Log.Info($"CI umarł - NTF +{1.2f * Core.WavesAmount}");
                        Core.LogTickets();
                        return;
                    }

                // NTF dying from "other means"
                if (ev.Player.IsNTF || ev.Player.Role == RoleTypeId.FacilityGuard)
                    if (Core.WavesAmount == 0)
                    {
                        Core.AddChaosTokens(1.2f);
                        Log.Info("NTF umarł - Chaos +1.2");
                        Core.LogTickets();
                        return;
                    }
                    else
                    {
                        Core.AddChaosTokens(1.2f * Core.WavesAmount);
                        Log.Info($"NTF umarł - Chaos +{1.2f * Core.WavesAmount}");
                        Core.LogTickets();
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
                    Log.Info($"NTF zabił SCP - NTF +3");
                    if (ev.Attacker.CurrentItem.Type == ItemType.MicroHID)
                    {
                        Core.AddNineTailedFoxTokens(1.5f);
                        Log.Info($"BONUS za użycie MicroHIDa - NTF +1.5");
                    }
                    Core.LogTickets();
                    return;
                }
                else if (ev.Attacker.Role.Team == Team.ChaosInsurgency || ev.Attacker.Role == RoleTypeId.ClassD)
                {
                    Core.AddChaosTokens(3f);
                    Log.Info($"Chaos zabił SCP - NTF +3");
                    if (ev.Attacker.CurrentItem.Type == ItemType.MicroHID)
                    {
                        Core.AddChaosTokens(1.5f);
                        Log.Info($"BONUS za użycie MicroHIDa - Chaos +1.5");
                    }
                    Core.LogTickets();
                    return;
                }
            }

            // NTF killing Chaos
            if (ev.Attacker.IsNTF || ev.Attacker.Role == RoleTypeId.FacilityGuard)
                if (ev.Player.IsCHI)
                {
                    Core.AddNineTailedFoxTokens(1.5f);
                    Log.Info("NTF zabił CI - NTF +1.5");
                    Core.LogTickets();
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
                    Log.Info("Ochroniarz zabił uzbrojoną Klasę D - NTF +1.5");
                    Core.LogTickets();
                    return;
                }
            }

            // Class D killing NTF
            if (ev.Attacker.Role == RoleTypeId.ClassD)
                if (ev.Player.IsNTF || ev.Player.Role == RoleTypeId.FacilityGuard)
                {
                    Core.AddChaosTokens(2f);
                    Log.Info("Klasa D zabiła NTF - Chaos +2");
                    Core.LogTickets();
                    return;
                }

            // Class D or Chaos killing Scientist
            if (ev.Attacker.IsCHI || ev.Attacker.Role == RoleTypeId.ClassD)
                if (ev.Player.Role == RoleTypeId.Scientist)
                {
                    Core.AddChaosTokens(1.4f);
                    Log.Info("Klasa D lub Chaos zabili Naukowca - Chaos +1.4");
                    Core.LogTickets();
                    return;
                }

            // Chaos killing NTF or Guard
            if (ev.Attacker.IsCHI)
                if (ev.Player.IsNTF || ev.Player.Role == RoleTypeId.FacilityGuard)
                {
                    Core.AddChaosTokens(1.5f);
                    Log.Info("Chaos zabił NTF - Chaos +1.5");
                    Core.LogTickets();
                    return;
                }
        }

        public void OnPlayerEscaping(EscapingEventArgs ev)
        {
            // Scientist escaping
            if (ev.Player.Role == RoleTypeId.Scientist)
            {
                Core.AddNineTailedFoxTokens(3f);
                Log.Info("Naukowiec uciekł - NTF +3");
                Core.LogTickets();
                return;
            }

            // Cuffed Class D escaping
            if (ev.Player.Role == RoleTypeId.ClassD && ev.Player.IsCuffed)
            {
                Core.AddNineTailedFoxTokens(3f);
                Log.Info("Związana Klasa D uciekła - NTF +3");
                Core.LogTickets();
                return;
            }

            // Class D escaping
            if (ev.Player.Role == RoleTypeId.ClassD)
            {
                Core.AddChaosTokens(4f);
                Log.Info("Klasa D uciekła - Chaos +4");
                Core.LogTickets();
                return;
            }
            
            // Cuffed Scientist escaping
            if (ev.Player.Role == RoleTypeId.Scientist && ev.Player.IsCuffed)
            {
                Core.AddChaosTokens(4f);
                Log.Info("Związany Naukowiec uciekł - Chaos +4");
                Core.LogTickets();
                return;
            }
        }

        public void OnGeneratorUnlocked(UnlockingGeneratorEventArgs ev)
        {
            if (ev.Player.CurrentItem.IsKeycard)
            {
                Keycard card = ev.Player.CurrentItem as Keycard;
                if (card.Permissions != KeycardPermissions.ArmoryLevelTwo)
                    return;
            }

            Core.AddNineTailedFoxTokens(0.5f);
            Log.Info("Odblokowano Generator - NTF +0.5");
            Core.LogTickets();
            return;
        }

        public void OnGeneratorEngaged(GeneratorActivatingEventArgs ev)
        {
            Core.AddNineTailedFoxTokens(1f);
            Log.Info("Uruchomiono Generator - NTF +1");
            Core.LogTickets();
            return;
        }

        public void OnPlayerMoveStateChange(ChangingMoveStateEventArgs ev)
        {
            // is a player civillian?
            if (!_civilliansReachedHeavy.ContainsKey(ev.Player))
                return;

            if (ev.Player.Role != RoleTypeId.ClassD || ev.Player.Role != RoleTypeId.Scientist)
            {
                _civilliansReachedHeavy.Remove(ev.Player);
                _civilliansReachedEntrance.Remove(ev.Player);
                _civilliansReachedSurface.Remove(ev.Player);
                return;
            }

            // civillian reaching HCZ
            if (ev.Player.Zone == ZoneType.HeavyContainment)
            {
                if (ev.Player.Role == RoleTypeId.Scientist || ev.Player.Role == RoleTypeId.ClassD)
                    if (_civilliansReachedHeavy.TryGetValue(ev.Player, out bool value) && value == false)
                    {
                        _civilliansReachedHeavy[ev.Player] = true;
                        Timing.RunCoroutine(HeavyCheckCoroutine(ev.Player));
                    }
            }

            // civillian reaching EZ
            if (ev.Player.Zone == ZoneType.Entrance)
            {
                if (ev.Player.Role == RoleTypeId.Scientist || ev.Player.Role == RoleTypeId.ClassD)
                    if (_civilliansReachedEntrance.TryGetValue(ev.Player, out bool value) && value == false)
                    {
                        _civilliansReachedEntrance[ev.Player] = true;
                        Timing.RunCoroutine(EntranceCheckCoroutine(ev.Player));
                    }
            }

            // civillian reaching Surface
            if (ev.Player.Zone == ZoneType.Surface)
            {
                if (ev.Player.Role == RoleTypeId.Scientist || ev.Player.Role == RoleTypeId.ClassD)
                    if (_civilliansReachedSurface.TryGetValue(ev.Player, out bool value) && value == false)
                    {
                        _civilliansReachedSurface[ev.Player] = true;
                        Timing.RunCoroutine(SurfaceCheckCoroutine(ev.Player));
                    }
            }
        }

        public void OnWarheadUnlock(ActivatingWarheadPanelEventArgs ev)
        {
            if (ev.Player.Role.Team == Team.FoundationForces || ev.Player.Role == RoleTypeId.Scientist)
            {
                Core.AddNineTailedFoxTokens(1f);
                Log.Info("NTF odblokował przycisk Warheadu - NTF +1");
                Core.LogTickets();
                return;
            }
            else if (ev.Player.Role.Team == Team.ChaosInsurgency || ev.Player.Role == RoleTypeId.ClassD)
            {
                Core.AddChaosTokens(1f);
                Log.Info("Chaos odblokował przycisk Warheadu - Chaos +1");
                Core.LogTickets();
                return;
            }
        }

        public void OnWarheadStarting(Exiled.Events.EventArgs.Warhead.StartingEventArgs ev)
        {
            _warheadStartedBy = ev.Player.Role.Team;
            Log.Info($"Warhead uruchomiony przez: {ev.Player.Role.Team}");
        }

        public void OnWarheadDetonating(Exiled.Events.EventArgs.Warhead.DetonatingEventArgs ev)
        {
            Timing.KillCoroutines("mainRespawn");
            Log.Info("Zresetowano timer respawnu ze względu na detonację Warheada.");
            Timing.RunCoroutine(Core.EnqueueSpawn(240f));

            if (_warheadStartedBy == Team.FoundationForces || _warheadStartedBy == Team.Scientists)
            {
                foreach (Player player in Player.List.ToList())
                {
                    if (player.Role == RoleTypeId.Scientist && player.Zone != ZoneType.Surface)
                        return;
                }

                Core.AddNineTailedFoxTokens(6f);
                Log.Info("NTF zdetonował Warheada - NTF +6");
                Core.LogTickets();
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
                Log.Info("Chaos zdetonował Warheada - Chaos +6");
                Core.LogTickets();
                return;
            }
        }

        public void OnRespawnWave(RespawnedTeamEventArgs ev)
        {
            Core.MainCountdownStarted = false;

            float tokensToRemove = 0;
            foreach (Player player in ev.Players.ToList())
            {
                tokensToRemove++;
            }

            if (ev.Wave.TargetFaction == Faction.FoundationStaff)
            {
                Core.AddChaosTokens(tokensToRemove);
                Log.Info($"NTF się zrespił - Chaos +{tokensToRemove}");
                Core.LogTickets();
                return;
            }

            if (ev.Wave.TargetFaction == Faction.FoundationEnemy)
            {
                Core.AddNineTailedFoxTokens(tokensToRemove);
                Log.Info($"Chaos się zrespił - NTF +{tokensToRemove}");
                Core.LogTickets();
                return;
            }
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
                        Log.Info("Naukowiec dotarł do HCZ - NTF +0.1");
                        Core.LogTickets();
                    }
                    else
                    {
                        Core.AddChaosTokens(0.1f);
                        Log.Info("Klasa D dotarła do HCZ - Chaos +0.1");
                        Core.LogTickets();
                    }
                }
                else
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddChaosTokens(0.1f);
                        Log.Info("Skuty Naukowiec dotarł do HCZ - Chaos +0.1");
                        Core.LogTickets();
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(0.1f);
                        Log.Info("Skuta Klasa D dotarła do HCZ - NTF +0.1");
                        Core.LogTickets();
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
                        Log.Info("Naukowiec dotarł do EZ - NTF +0.15");
                        Core.LogTickets();
                    }
                    else
                    {
                        Core.AddChaosTokens(0.15f);
                        Log.Info("Klasa D dotarła do EZ - Chaos +0.15");
                        Core.LogTickets();
                    }
                }
                else
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddChaosTokens(0.15f);
                        Log.Info("Skuty Naukowiec dotarł do EZ - Chaos +0.15");
                        Core.LogTickets();
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(0.15f);
                        Log.Info("Skuta Klasa D dotarła do EZ - NTF +0.15");
                        Core.LogTickets();
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
                        Log.Info("Naukowiec dotarł na powierzchnię - NTF +0.2");
                        Core.LogTickets();
                    }
                    else
                    {
                        Core.AddChaosTokens(0.2f);
                        Log.Info("Klasa D dotarła do na powierzchnię - Chaos +0.2");
                        Core.LogTickets();
                    }
                }
                else
                {
                    if (player.Role == RoleTypeId.Scientist)
                    {
                        Core.AddChaosTokens(0.2f);
                        Log.Info("Skuty Naukowiec dotarł na powierzchnię - Chaos +0.2");
                        Core.LogTickets();
                    }
                    else
                    {
                        Core.AddNineTailedFoxTokens(0.2f);
                        Log.Info("Skuta Klasa D dotarła na powierzchnię - NTF +0.2");
                        Core.LogTickets();
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
