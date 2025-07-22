using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using GejlonForExiledV2.BadLuckProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace GejlonForExiledV2.CoinSystem
{
    public class EventHandlers
    {
        public CoinSystemCore CoinCore;
        public BadLuckProtectionCore BadLuckCore;

        public void OnPlayerCoinFlipping(FlippingCoinEventArgs ev)
        {
            bool canExecute = false;

            CoinPossibility possibility = null;
            
            PlayerCoinData coinData;

            bool dictionaryHadPlayer = BadLuckCore.DataDictionary.TryGetValue(ev.Player.UserId, out PlayerCoinData data);

            if (dictionaryHadPlayer)
            {
                coinData = data;
            }
            else
            {
                coinData = new PlayerCoinData();
            }

            List<(CoinPossibility, float)> weightedList = new List<(CoinPossibility possibility, float finalWeight)>();

            foreach (CoinPossibility option in CoinCore.ValidCoinPossibilities)
            {
                float multiplier = BadLuckCore.CalculateWeightMultiplier(coinData, option.Type);
                weightedList.Add((option, option.Weight * multiplier));
            }

            int totalWeight = weightedList.Sum(x => (int)Math.Floor(x.Item2));
            int rollValue = Random.Range(0, totalWeight);

            int cumulatedWeight = 0;

            foreach (CoinPossibility coinPossibility in Plugin.Instance.CoinSystemCore.ValidCoinPossibilities)
            {
                cumulatedWeight += coinPossibility.Weight;
                if (rollValue < cumulatedWeight)
                {
                    possibility = coinPossibility;
                    canExecute = coinPossibility.CanExecute(ev.Player);
                    break;
                }
            }

            while (!canExecute)
            {
                rollValue = Random.Range(0, totalWeight);

                cumulatedWeight = 0;

                foreach (CoinPossibility coinPossibility in Plugin.Instance.CoinSystemCore.ValidCoinPossibilities)
                {
                    cumulatedWeight += coinPossibility.Weight;
                    if (rollValue < cumulatedWeight)
                    {
                        possibility = coinPossibility;
                        canExecute = coinPossibility.CanExecute(ev.Player);
                        break;
                    }
                }
            }

            Log.Info(ev.Player.Nickname + " rzucił monetą i trafił " + possibility.Id);

            ev.Player.RemoveHeldItem();

            possibility.Execute(ev.Player);
            ev.Player.ShowHint(possibility.Hint, possibility.HintDuration);

            coinData.TotalRolls++;

            if (possibility.Type == PossibilityType.Negative)
            {
                coinData.NegativeRolls++;
                coinData.NegativeStreak++;
                coinData.PositiveSinceLastNegative = 0;
            }
            else if (possibility.Type == PossibilityType.Positive)
            {
                coinData.NegativeStreak = 0;
                coinData.PositiveSinceLastNegative++;
                coinData.PositiveRolls++;
            }

            if (dictionaryHadPlayer)
            {
                BadLuckCore.DataDictionary[ev.Player.UserId] = coinData;
            }
            else
            {
                BadLuckCore.DataDictionary.Add(ev.Player.UserId, coinData);
            }

            return;
        }

        public void OnServerRestarting()
        {
            Plugin.Instance.BadLuckProtectionCore.SaveData();
        }
    }
}
