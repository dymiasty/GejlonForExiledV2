using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
using APIPlayer = Exiled.API.Features.Player;
using InventorySystem.Items.Usables.Scp330;
using MEC;
using System.Linq;
using PlayerRoles;

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
        public override Version RequiredExiledVersion => new Version(9, 2, 2);
        public override string Author => "dymiasty";
        public override Version Version => new Version(0, 1, 4);

        private EventHandlers Handlers { get; set; }

        public CoinMachine CoinMachine { get; set; }

        public override void OnEnabled()
        {
            Log.Info("Plugin GejlonForExiledV2 w wersji " + Version + " został uruchomiony.");

            Handlers = new EventHandlers();
            CoinMachine = new CoinMachine();

            // Server events
            Server.WaitingForPlayers += Handlers.OnWaitingForPlayers;
            Server.RoundStarted += Handlers.OnRoundStarted;

            // Player events
            Player.FlippingCoin += Handlers.OnPlayerCoinFlipping;
            Player.Spawned += Handlers.OnPlayerSpawned;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("Plugin GejlonForExiledV2 został wyłączony.");

            // Server events
            Server.WaitingForPlayers -= Handlers.OnWaitingForPlayers;
            Server.RoundStarted -= Handlers.OnRoundStarted;

            // Player events
            Player.FlippingCoin -= Handlers.OnPlayerCoinFlipping;
            Player.Spawned -= Handlers.OnPlayerSpawned;

            Handlers = null;
            CoinMachine = null;

            base.OnDisabled();
        }

        public List<APIPlayer> GetPeopleInLCZ()
        {
            List<APIPlayer> peopleInLCZ = new List<APIPlayer>();

            foreach (APIPlayer player in APIPlayer.List)
            {
                foreach (APIPlayer playerr in peopleInLCZ)
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

        public List<APIPlayer> GetLivingSCPs()
        {
            List<APIPlayer> livingSCPs = new List<APIPlayer>();

            foreach (APIPlayer player in APIPlayer.List)
            {
                foreach (APIPlayer playerr in livingSCPs)
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

        public APIPlayer RandomAlivePlayer()
        {
            APIPlayer randomPlayer;

            randomPlayer = APIPlayer.List.ToList()[Random.Range(0, APIPlayer.List.ToList().Count)];

            while (randomPlayer.IsDead || randomPlayer.IsNPC)
            {
                randomPlayer = APIPlayer.List.ToList()[Random.Range(0, APIPlayer.List.ToList().Count)];
            }

            return randomPlayer;
        }

        public APIPlayer RandomHumanPlayer()
        {
            APIPlayer randomPlayer;

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

            role = (RoleTypeId)Random.Range(0, 28);

            while (new RoleTypeId[] { (RoleTypeId)2, (RoleTypeId)14, (RoleTypeId)17, (RoleTypeId)21, (RoleTypeId)22, (RoleTypeId)23, (RoleTypeId)24 }.Contains(role))
            {
                role = (RoleTypeId)Random.Range(0, 28);
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

        public IEnumerator<float> GodPlayer(APIPlayer player, float duration)
        {
            player.IsGodModeEnabled = true;
            yield return Timing.WaitForSeconds(duration);
            player.IsGodModeEnabled = false;
        }
    }
}
