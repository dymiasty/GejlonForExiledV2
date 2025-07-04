﻿using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using System.Collections.Generic;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace GejlonForExiledV2.RespawnSystem
{
    public class RespawnSystemCore
    {
        private EventHandlers Events { get; set; }

        public float NineTailedFoxTokens;
        public float ChaosTokens;

        public bool MainCountdownStarted = false;

        public int WavesAmount = 0;

        public void SubscribeEvents()
        {
            Events = new EventHandlers();

            ServerEvents.WaitingForPlayers += _enabledMessage;
            ServerEvents.RoundStarted += Events.OnRoundStarted;
            ServerEvents.SelectingRespawnTeam += Events.OnSelectingRespawnTeam;
            ServerEvents.RespawnedTeam += Events.OnRespawnWave;
            ServerEvents.RoundEnded += Events.OnRoundEnded;

            PlayerEvents.Dying += Events.OnPlayerDying;
            PlayerEvents.Escaping += Events.OnPlayerEscaping;
            PlayerEvents.UnlockingGenerator += Events.OnGeneratorUnlocked;
            PlayerEvents.Spawned += Events.OnPlayerSpawned;
            PlayerEvents.ChangingMoveState += Events.OnPlayerMoveStateChange;
            PlayerEvents.Shot += Events.OnPlayerShot;
            PlayerEvents.ItemAdded += Events.OnItemPickedUp;
            PlayerEvents.ItemRemoved += Events.OnItemDropped;
            PlayerEvents.ActivatingWarheadPanel += Events.OnWarheadUnlock;
            PlayerEvents.Hurt += Events.OnPlayerHurt;
            PlayerEvents.Died += Events.OnPlayerDied;

            Exiled.Events.Handlers.Warhead.Starting += Events.OnWarheadStarting;
            Exiled.Events.Handlers.Warhead.Detonating += Events.OnWarheadDetonating;

            Exiled.Events.Handlers.Map.GeneratorActivating += Events.OnGeneratorEngaged;
        }

        public void UnsubscribeEvents()
        {
            ServerEvents.WaitingForPlayers -= _enabledMessage;
            ServerEvents.RoundStarted -= Events.OnRoundStarted;
            ServerEvents.SelectingRespawnTeam -= Events.OnSelectingRespawnTeam;
            ServerEvents.RespawnedTeam -= Events.OnRespawnWave;
            ServerEvents.RoundEnded -= Events.OnRoundEnded;

            PlayerEvents.Dying -= Events.OnPlayerDying;
            PlayerEvents.Escaping -= Events.OnPlayerEscaping;
            PlayerEvents.UnlockingGenerator -= Events.OnGeneratorUnlocked;
            PlayerEvents.Spawned -= Events.OnPlayerSpawned;
            PlayerEvents.ChangingMoveState -= Events.OnPlayerMoveStateChange;
            PlayerEvents.Shot -= Events.OnPlayerShot;
            PlayerEvents.ItemAdded -= Events.OnItemPickedUp;
            PlayerEvents.ItemRemoved -= Events.OnItemDropped;
            PlayerEvents.ActivatingWarheadPanel -= Events.OnWarheadUnlock;
            PlayerEvents.Hurt -= Events.OnPlayerHurt;
            PlayerEvents.Died -= Events.OnPlayerDied;

            Exiled.Events.Handlers.Warhead.Starting -= Events.OnWarheadStarting;
            Exiled.Events.Handlers.Warhead.Detonating -= Events.OnWarheadDetonating;

            Exiled.Events.Handlers.Map.GeneratorActivating -= Events.OnGeneratorEngaged;

            Events = null;
        }

        public void AddChaosTokens(float amount)
        {
            ChaosTokens += amount;
            NineTailedFoxTokens -= amount;
        }

        public void AddNineTailedFoxTokens(float amount)
        {
            NineTailedFoxTokens += amount;
            ChaosTokens -= amount;
        }

        private void _enabledMessage()
        {
            Log.Info("Old Respawn System BETA enabled.");
        }

        public void LogTickets()
        {
            Log.Info($"\nStan tokenów: \n" +
                $"Nine-Tailed Fox: {NineTailedFoxTokens}\n" +
                $"Rebelia Chaosu: {ChaosTokens}");
        }


        public IEnumerator<float> EnqueueSpawn(float timeToSpawn)
        {
            yield return Timing.WaitForSeconds(timeToSpawn);
            if (NineTailedFoxTokens >= ChaosTokens)
                Timing.RunCoroutine(SpawnNTF());
            else
                Timing.RunCoroutine(SpawnCI());
        }


        public IEnumerator<float> SpawnCI()
        {
            if (Plugin.Instance.IsRespawning)
                yield break;

            Plugin.Instance.IsRespawning = true;
            Respawn.SummonChaosInsurgencyVan();
            yield return Timing.WaitForSeconds(10f);
            Respawn.ForceWave(SpawnableFaction.ChaosWave);
            Plugin.Instance.IsRespawning = false;
            WavesAmount++;
        }

        public IEnumerator<float> SpawnNTF()
        {
            if (Plugin.Instance.IsRespawning)
                yield break;

            Plugin.Instance.IsRespawning = true;
            Respawn.SummonNtfChopper();
            yield return Timing.WaitForSeconds(18.8f);
            Respawn.ForceWave(SpawnableFaction.NtfWave);
            Plugin.Instance.IsRespawning = false;
            WavesAmount++;
        }
    }
}
