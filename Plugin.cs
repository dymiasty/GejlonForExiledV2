using Exiled.API.Features;
using System;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;
using EventHandlers = GejlonForExiledV2.General.EventHandlers;
using GejlonForExiledV2.RespawnSystem;
using GejlonForExiledV2.BadLuckProtection;
using GejlonForExiledV2.CoinSystem;
using GejlonForExiledV2.RespawnSystem.RespawnTimer;
using GejlonForExiledV2.ReviveSystem;
using GejlonForExiledV2.SCPLifesteal;

namespace GejlonForExiledV2
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }
        public override string Name => "GejlonForExiledV2";
        public override string Prefix => "GFEV2";
        public override Version RequiredExiledVersion => new Version(9, 9, 2);
        public override string Author => "dymiasty";
        public override Version Version => new Version(0, 3, 6);

        private EventHandlers GeneralHandlers { get; set; }

        public RespawnSystemCore RespawnSystemCore { get; private set; }

        public CoinSystemCore CoinSystemCore { get; private set; }

        public BadLuckProtectionCore BadLuckProtectionCore { get; private set; }

        public RespawnTimerCore RespawnTimerCore { get; private set; }

        public ReviveSystemCore ReviveSystemCore { get; private set; }

        public SCPLifestealCore SCPLifestealCore { get; private set; }


        public override void OnEnabled()
        {
            Instance = this;

            GeneralHandlers = new EventHandlers();
            CoinSystemCore = new CoinSystemCore();
            RespawnSystemCore = new RespawnSystemCore();
            RespawnTimerCore = new RespawnTimerCore();
            ReviveSystemCore = new ReviveSystemCore();
            SCPLifestealCore = new SCPLifestealCore();
            
            BadLuckProtectionCore = new BadLuckProtectionCore();
            
            SubscribeEvents();

            if (Config.CoinsEnabled)
            {
                BadLuckProtectionCore.LoadData();
                CoinSystemCore.SubscribeEvents();
            }
            
            if (Config.OldRespawnSystemEnabled)
            {
                RespawnSystemCore.SubscribeEvents();

                if (Config.RespawnTimer)
                    RespawnTimerCore.SubscribeEvents();
            }

            if (Config.RevivingEnabled)
                ReviveSystemCore.SubscribeEvents();

            if (Config.SCPLifestealEnabled)
                SCPLifestealCore.SubscribeEvents();


            base.OnEnabled();
            Log.Info($"Plugin GejlonForExiledV2 w wersji {Version} został uruchomiony.");
        }

        public override void OnDisabled()
        {
            SCPLifestealCore.UnsubscribeEvents();
            ReviveSystemCore.UnsubscribeEvents();
            CoinSystemCore.UnsubscribeEvents();
            RespawnTimerCore.UnsubscribeEvents();
            RespawnSystemCore.UnsubscribeEvents();
            UnsubscribeEvents();

            if (Config.CoinsEnabled)
                BadLuckProtectionCore.SaveData();

            BadLuckProtectionCore = null;

            SCPLifestealCore = null;
            RespawnTimerCore = null;
            RespawnSystemCore = null;
            CoinSystemCore = null;
            GeneralHandlers = null;

            Instance = null;
            base.OnDisabled();
        }

        private void SubscribeEvents()
        {
            ServerEvents.WaitingForPlayers += GeneralHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted += GeneralHandlers.OnRoundStarted;

            if (Config.AutoDeadmanDisable)
            {
                ServerEvents.RoundStarted += GeneralHandlers.OnRoundStartedDeadman;
            }

            if (Config.CoinsEnabled)
            {
                PlayerEvents.Spawned += GeneralHandlers.OnPlayerSpawned;
                ServerEvents.RoundStarted += GeneralHandlers.OnRoundStartedCoinWarhead;
            }
            
            if (Config.WeaponJammingEnabled)
                PlayerEvents.Shooting += GeneralHandlers.OnPlayerShooting;

            ServerEvents.RoundEnded += GeneralHandlers.OnRoundEnded;
        }

        private void UnsubscribeEvents()
        {
            // Server events
            ServerEvents.WaitingForPlayers -= GeneralHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted -= GeneralHandlers.OnRoundStarted;
            ServerEvents.RoundEnded -= GeneralHandlers.OnRoundEnded;

            // Player events
            PlayerEvents.Spawned -= GeneralHandlers.OnPlayerSpawned;
            PlayerEvents.Shooting -= GeneralHandlers.OnPlayerShooting;
        }
    }
}
