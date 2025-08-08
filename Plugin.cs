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

namespace GejlonForExiledV2
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }
        public override string Name => "GejlonForExiledV2";
        public override string Prefix => "GFEV2";
        public override Version RequiredExiledVersion => new Version(9, 7, 2);
        public override string Author => "dymiasty";
        public override Version Version => new Version(0, 3, 3);

        private EventHandlers MainHandlers { get; set; }

        public RespawnSystemCore RespawnSystemCore { get; private set; }

        public CoinSystemCore CoinSystemCore { get; private set; }

        public BadLuckProtectionCore BadLuckProtectionCore { get; private set; }

        public RespawnTimerCore RespawnTimerCore { get; private set; }

        public ReviveSystemCore ReviveSystemCore { get; private set; }


        public override void OnEnabled()
        {
            Instance = this;

            MainHandlers = new EventHandlers();
            CoinSystemCore = new CoinSystemCore();
            RespawnSystemCore = new RespawnSystemCore();
            RespawnTimerCore = new RespawnTimerCore();
            ReviveSystemCore = new ReviveSystemCore();
            
            BadLuckProtectionCore = new BadLuckProtectionCore();
            BadLuckProtectionCore.LoadData();
            
            SubscribeEvents();
            RespawnSystemCore.SubscribeEvents();
            RespawnTimerCore.SubscribeEvents();
            CoinSystemCore.SubscribeEvents();
            ReviveSystemCore.SubscribeEvents();


            base.OnEnabled();
            Log.Info($"Plugin GejlonForExiledV2 w wersji {Version} został uruchomiony.");
        }

        public override void OnDisabled()
        {
            ReviveSystemCore.UnsubscribeEvents();
            CoinSystemCore.UnsubscribeEvents();
            RespawnTimerCore.UnsubscribeEvents();
            RespawnSystemCore.UnsubscribeEvents();
            UnsubscribeEvents();

            BadLuckProtectionCore = null;
            BadLuckProtectionCore.SaveData();

            RespawnTimerCore = null;
            RespawnSystemCore = null;
            CoinSystemCore = null;
            MainHandlers = null;

            Instance = null;
            base.OnDisabled();
        }

        private void SubscribeEvents()
        {
            // Server events
            ServerEvents.WaitingForPlayers += MainHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted += MainHandlers.OnRoundStarted;
            ServerEvents.RoundEnded += MainHandlers.OnRoundEnded;

            // Player events
            PlayerEvents.Spawned += MainHandlers.OnPlayerSpawned;
            PlayerEvents.Shooting += MainHandlers.OnPlayerShooting;
        }

        private void UnsubscribeEvents()
        {
            // Server events
            ServerEvents.WaitingForPlayers -= MainHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted -= MainHandlers.OnRoundStarted;
            ServerEvents.RoundEnded -= MainHandlers.OnRoundEnded;

            // Player events
            PlayerEvents.Spawned -= MainHandlers.OnPlayerSpawned;
            PlayerEvents.Shooting -= MainHandlers.OnPlayerShooting;
        }
    }
}
