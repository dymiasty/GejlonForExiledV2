using Exiled.API.Features;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.BadLuckProtection
{
    public class BadLuckProtectionCore
    {
        public Dictionary<string, PlayerCoinData> DataDictionary;

        private string filePath;

        public void LoadData()
        {
            Paths.Reload();

            filePath = Path.Combine(Paths.IndividualConfigs, "GFEV2", "badluck.json");

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(jsonContent))
                {
                    DataDictionary = JsonConvert.DeserializeObject<Dictionary<string, PlayerCoinData>>(jsonContent);
                    Log.Info("Wczytano plik badluck.json");
                }
                else
                {
                    Log.Info($"Plik badluck.json jest pusty.");
                    DataDictionary = new Dictionary<string, PlayerCoinData>();
                }
            }
            else
            {
                Log.Info("Plik badluck.json nie istnieje. Tworzenie...");
                var file = File.CreateText(filePath);
                file.Close();

                DataDictionary = new Dictionary<string, PlayerCoinData>();
            }
        }

        public void SaveData()
        {
            Paths.Reload();

            string jsonContent = JsonConvert.SerializeObject(DataDictionary, Formatting.Indented);

            File.WriteAllText(filePath, jsonContent);

            Log.Info("Zapisano plik badluck.json.");
        }

        public float CalculateWeightMultiplier(PlayerCoinData coinData, PossibilityType type)
        {
            if (type == PossibilityType.Positive)
            {
                return 1f + (coinData.NegativeStreak * 0.1f);
            }

            if (type == PossibilityType.Negative)
            {
                return 1f - Math.Min(coinData.NegativeStreak * 0.05f, 0.5f);
            }

            return 1f;
        }
    }
}
