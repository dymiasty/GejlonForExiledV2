using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;
using InventorySystem.Items.Usables.Scp330;
using MEC;
using System.Linq;
using PlayerRoles;
using GejlonForExiledV2.RespawnSystem;
using GejlonForExiledV2.BadLuckProtection;
using GejlonForExiledV2.CoinSystem;
using GejlonForExiledV2.RespawnSystem.RespawnTimer;

namespace GejlonForExiledV2
{
    public class Plugin : Plugin<Config>
    {
        public Plugin()
        {
            Instance = this;
        }

        public static Plugin Instance { get; private set; }
        public override string Name => "GejlonForExiledV2";
        public override string Prefix => "GFEV2";
        public override Version RequiredExiledVersion => new Version(9, 6, 3);
        public override string Author => "dymiasty";
        public override Version Version => new Version(0, 3, 2);

        private EventHandlers MainHandlers { get; set; }

        public RespawnSystemCore RespawnSystemCore { get; private set; }

        public CoinSystemCore CoinSystemCore { get; private set; }

        public BadLuckProtectionCore BadLuckProtectionCore { get; private set; }

        public RespawnTimerCore RespawnTimerCore { get; private set; }


        public override void OnEnabled()
        {
            Log.Info($"Plugin GejlonForExiledV2 w wersji {Version} został uruchomiony.");

            MainHandlers = new EventHandlers();
            CoinSystemCore = new CoinSystemCore();
            RespawnSystemCore = new RespawnSystemCore();
            RespawnTimerCore = new RespawnTimerCore();

            BadLuckProtectionCore = new BadLuckProtectionCore();
            
            SubscribeEvents();
            RespawnSystemCore.SubscribeEvents();
            RespawnTimerCore.SubscribeEvents();
            CoinSystemCore.SubscribeEvents();


            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            CoinSystemCore.UnsubscribeEvents();
            RespawnTimerCore.UnsubscribeEvents();
            RespawnSystemCore.UnsubscribeEvents();
            UnsubscribeEvents();

            BadLuckProtectionCore = null;

            RespawnTimerCore = null;
            RespawnSystemCore = null;
            CoinSystemCore = null;
            MainHandlers = null;

            base.OnDisabled();
        }

        private void SubscribeEvents()
        {
            // Server events
            ServerEvents.WaitingForPlayers += MainHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted += MainHandlers.OnRoundStarted;

            // Player events
            PlayerEvents.Spawned += MainHandlers.OnPlayerSpawned;
            PlayerEvents.Shooting += MainHandlers.OnPlayerShooting;
        }

        private void UnsubscribeEvents()
        {
            // Server events
            ServerEvents.WaitingForPlayers -= MainHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted -= MainHandlers.OnRoundStarted;

            // Player events
            PlayerEvents.Spawned -= MainHandlers.OnPlayerSpawned;
            PlayerEvents.Shooting -= MainHandlers.OnPlayerShooting;
        }

        public List<Player> GetPeopleInLCZ()
        {
            List<Player> peopleInLCZ = new List<Player>();

            foreach (Player player in Player.List)
            {
                foreach (Player playerr in peopleInLCZ)
                {
                    if (playerr.IsDead)
                    {
                        peopleInLCZ.Remove(playerr);
                    }
                }
                if (player.Zone == ZoneType.LightContainment)
                {
                    if (player.IsAlive)
                    {
                        peopleInLCZ.Add(player);
                    }
                }
            }

            return peopleInLCZ;
        }

        public List<Player> GetLivingSCPs()
        {
            List<Player> livingSCPs = new List<Player>();

            foreach (Player player in Player.List)
            {
                foreach (Player playerr in livingSCPs)
                {
                    if (playerr.IsDead)
                    {
                        livingSCPs.Remove(playerr);
                    }
                }
                if (player.IsScp)
                {
                    if (player.IsAlive)
                    {
                        livingSCPs.Add(player);
                    }
                }
            }

            return livingSCPs;
        }

        public Player RandomAlivePlayer()
        {
            Player randomPlayer;

            randomPlayer = Player.List.ToList()[Random.Range(0, Player.List.ToList().Count)];

            while (randomPlayer.IsDead || randomPlayer.IsNPC)
            {
                randomPlayer = Player.List.ToList()[Random.Range(0, Player.List.ToList().Count)];
            }

            return randomPlayer;
        }

        public Player RandomHumanPlayer()
        {
            Player randomPlayer;

            randomPlayer = RandomAlivePlayer();

            while (randomPlayer.IsDead || randomPlayer.IsNPC || randomPlayer.IsScp)
            {
                randomPlayer = RandomAlivePlayer();
            }

            return randomPlayer;
        }

        public RoleTypeId RandomRole()
        {
            RoleTypeId role;

            role = (RoleTypeId)Random.Range(0, 25);

            while (new RoleTypeId[] { (RoleTypeId)2, (RoleTypeId)14, (RoleTypeId)17, (RoleTypeId)21, (RoleTypeId)22, (RoleTypeId)23, (RoleTypeId)24 }.Contains(role))
            {
                role = (RoleTypeId)Random.Range(0, 25);
            }

            return role;
        }

        public ItemType GenerateRandomKeycard()
        {
            int keycardNumericId = Random.Range(1, 11);

            switch (keycardNumericId)
            {
                default:
                    return ItemType.Coal;
                case 1:
                        return ItemType.KeycardJanitor;
                case 2:
                        return ItemType.KeycardScientist;
                case 3:
                        return ItemType.KeycardResearchCoordinator;
                case 4:
                        return ItemType.KeycardGuard;
                case 5:
                        return ItemType.KeycardMTFOperative;
                case 6:
                        return ItemType.KeycardMTFCaptain;
                case 7:
                        return ItemType.KeycardZoneManager;
                case 8:
                        return ItemType.KeycardFacilityManager;
                case 9:
                        return ItemType.KeycardChaosInsurgency;
                case 10:
                        return ItemType.KeycardO5;
            }
        }

        public ItemType GenerateRandomSpecialWeapon()
        {
            int specialItemGenerated = Random.Range(1, 6);

            switch (specialItemGenerated)
            {
                default:
                    return ItemType.Coal;
                case 1:
                    return ItemType.ParticleDisruptor;
                case 2:
                    return ItemType.GunCom45;
                case 3:
                    return ItemType.Jailbird;
                case 4:
                    return ItemType.MicroHID;
                case 5:
                    return ItemType.GunA7;
            }
        }

        public ItemType GenerateRandomScpItem()
        {
            int item = Random.Range(1, 12);

            switch (item)
            {
                default:
                    return ItemType.Coal;
                case 1:
                    return ItemType.AntiSCP207;
                case 2:
                    return ItemType.SCP018;
                case 3:
                    return ItemType.SCP207;
                case 4:
                    return ItemType.SCP244a;
                case 5:
                    return ItemType.SCP244b;
                case 6:
                    return ItemType.SCP268;
                case 7:
                    return ItemType.SCP500;
                case 8:
                    return ItemType.SCP1344;
                case 9:
                    return ItemType.SCP1576;
                case 10:
                    return ItemType.SCP1853;
                case 11:
                    return ItemType.SCP2176;
            }
        }

        public ItemType GenerateRandomMedicalItem()
        {
            int item = Random.Range(1, 4);

            switch (item)
            {
                default:
                    return ItemType.Coal;
                case 1:
                    return ItemType.Adrenaline;
                case 2:
                    return ItemType.Medkit;
                case 3:
                    return ItemType.Painkillers;
            }
        }

        public CandyKindID GenerateRandomCandy()
        {
            int item = Random.Range(1, 8);

            switch (item)
            {
                default:
                    return CandyKindID.None;
                case 1:
                    return CandyKindID.Blue;
                case 2:
                    return CandyKindID.Green;
                case 3:
                    return CandyKindID.Purple;
                case 4:
                    return CandyKindID.Rainbow;
                case 5:
                    return CandyKindID.Red;
                case 6:
                    return CandyKindID.Yellow;
                case 7:
                    return CandyKindID.Pink;
            }
        }

        public IEnumerator<float> GodPlayer(Player player, float duration)
        {
            player.IsGodModeEnabled = true;
            yield return Timing.WaitForSeconds(duration);
            player.IsGodModeEnabled = false;
        }

        public ItemType UpgradeKeycard(ItemType initialKeycard)
        {
            switch (initialKeycard)
            {
                default:
                    return initialKeycard;
                case ItemType.KeycardJanitor:
                    return ItemType.KeycardScientist;
                case ItemType.KeycardScientist:
                    return ItemType.KeycardResearchCoordinator;
                case ItemType.KeycardZoneManager:
                    return ItemType.KeycardFacilityManager;
                case ItemType.KeycardResearchCoordinator:
                    return ItemType.KeycardFacilityManager;
                case ItemType.KeycardFacilityManager:
                    return ItemType.KeycardO5;
                case ItemType.KeycardGuard:
                    return ItemType.KeycardMTFOperative;
                case ItemType.KeycardMTFOperative:
                    return ItemType.KeycardMTFCaptain;
                case ItemType.KeycardMTFCaptain:
                    return ItemType.KeycardO5;
                case ItemType.KeycardChaosInsurgency:
                    return ItemType.KeycardO5;
            }
        }

        public ItemType DowngradeKeycard(ItemType initialKeycard)
        {
            switch (initialKeycard)
            {
                default:
                    return initialKeycard;
                case ItemType.KeycardJanitor:
                    return ItemType.KeycardJanitor;
                case ItemType.KeycardScientist:
                    return ItemType.KeycardJanitor;
                case ItemType.KeycardZoneManager:
                    return ItemType.KeycardScientist;
                case ItemType.KeycardResearchCoordinator:
                    return ItemType.KeycardScientist;
                case ItemType.KeycardGuard:
                    return ItemType.KeycardScientist;
                case ItemType.KeycardMTFOperative:
                    return ItemType.KeycardGuard;
                case ItemType.KeycardMTFCaptain:
                    return ItemType.KeycardMTFOperative;
                case ItemType.KeycardFacilityManager:
                    return ItemType.KeycardMTFCaptain;
                case ItemType.KeycardChaosInsurgency:
                    return ItemType.KeycardMTFOperative;
                case ItemType.KeycardO5:
                    int card = Random.Range(0, 2);

                    if (card == 0)
                    {
                        return ItemType.KeycardFacilityManager;
                    }
                    else
                    {
                        return ItemType.KeycardMTFCaptain;
                    }
            }
        }
    }
}
