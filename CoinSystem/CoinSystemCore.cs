using GejlonForExiledV2.CoinSystem.CoinPossibilities;
using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace GejlonForExiledV2.CoinSystem
{
    public class CoinSystemCore
    {
        public EventHandlers Events { get; private set; }

        public void SubscribeEvents()
        {
            Events = new EventHandlers();

            PlayerEvents.FlippingCoin += Events.OnPlayerCoinFlipping;
            
            ServerEvents.RoundStarted += Events.OnRoundStarted;
            ServerEvents.RestartingRound += Events.OnServerRestarting;
        }

        public void UnsubscribeEvents()
        {
            PlayerEvents.FlippingCoin -= Events.OnPlayerCoinFlipping;

            ServerEvents.RoundStarted -= Events.OnRoundStarted;
            ServerEvents.RestartingRound -= Events.OnServerRestarting;

            Events = null;
        }

        /// <summary>
        /// List of all <seealso cref="CoinPossibility">Coin Possibilities</seealso>
        /// that flipping a coin can generate.
        /// </summary>
        public readonly List<CoinPossibility> ValidCoinPossibilities = new List<CoinPossibility>
        {
            new Ahp40(), // 0
            new AntiCola(), // 1
            new Blackout(), // 2
            new Candy(), // 3
            new CIWave(), // 4
            new ClearAmmo(), // 5
            new ClearInventory(), // 6
            new ClearKeycards(), // 7
            new Com15(), // 8
            new Crossvec(), // 9
            new DoorSystemRestart(), // 10
            new EscapeTeleport(), // 11
            new Explode(), // 12
            new EyesSevered(), // 13
            new Flashbang(), // 14
            new Flashlight(), // 15
            new FRMG0(), // 16
            new FullHeal(), // 17
            new Ghost(), // 18
            new Grenade(), // 19
            new HandsSevered(), // 20
            new HealFor50(), // 21
            new NTFWave(), // 22
            new O5Keycard(), // 23
            new OneHp(), // 24
            new PocketDimension(), // 25
            new QuickDecontamination(), // 26
            new Radio(), // 27
            new RandomPositiveEffect(), // 28
            new RandomKeycard(), // 29
            new RandomPlayerExplode(), // 30
            new RandomScpItem(), // 31
            new RandomScpTeleport(), // 32
            new RandomSpecialWeapon(), // 33
            new RandomTeleport(), // 34
            new WarheadDetonate(), // 35
            new WarheadTrigger(), // 36
            new WeaponExchange(), // 37
            new RandomMedItem(), // 38
            new InventorySwap(), // 39
            new RandomRole(), // 40
            new PosistionSwap(), // 41
            new LifeSwap(), // 42
            new UpgradeKeycards(), // 43
            new DowngradeKeycards(), // 44
            new MaxHealthIncrease(), // 45
            new SizeReduce(), // 46
        };

        /// <returns>
        /// Possibility of numeric id from <paramref name="index"/>.
        /// </returns>
        /// <param name="index">Index of an option from
        /// <see cref="ValidCoinPossibilities"/> list.
        /// </param>
        /// <returns></returns>
        public CoinPossibility GetPossibility(int index)
        {
            return ValidCoinPossibilities[index];
        }

        /// <returns>
        /// A really long string containing
        /// a list of every possibility and its chance
        /// example: possibilityId - (percentageChance%)
        /// </returns>
        public static string CalculateChances()
        {
            float weightSum = 0;
            foreach (CoinPossibility possibility in Plugin.Instance.CoinSystemCore.ValidCoinPossibilities)
            {
                weightSum += possibility.Weight;
            }

            string chances = "Lista szans wszystkich dostępnych opcji monet:\n";
            foreach (CoinPossibility possibility in Plugin.Instance.CoinSystemCore.ValidCoinPossibilities)
            {
                chances += $"{possibility.Id} - (~{Math.Round(possibility.Weight / weightSum * 100f, 2)}%)\n";
            }

            return chances;
        }

        /// <summary>
        /// A debug command made for testing
        /// coin flipping possibilities.
        /// 
        /// The only parameter it takes is numeric id corresponding
        /// to a possibility in the <see cref="ValidCoinPossibilities"/> list.
        /// </summary>
        [CommandHandler(typeof(RemoteAdminCommandHandler))]
        public class CoinDebugCommand : ICommand
        {
            public string Command => "coin";

            public string[] Aliases => null;

            public string Description => "Coin testing";

            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                Player player = Player.Get(sender);
                Log.Info(player.Nickname + " użył komendy testującej monety z parametrem " + arguments.ElementAt(0) + ".");
                bool canExecute;
                int wynik = int.Parse(arguments.ElementAt(0));
                CoinPossibility possibility = Plugin.Instance.CoinSystemCore.GetPossibility(wynik);
                Log.Info(player.Nickname + " rzucił monetą i trafił " + possibility.Id);

                canExecute = possibility.CanExecute(player);

                if (!canExecute)
                {
                    player.ShowHint("Nic się nie stało...", 6f);
                    response = "done.";
                    return true;
                }

                possibility.Execute(player);
                player.ShowHint(possibility.Hint, possibility.HintDuration);

                response = "done.";
                return true;
            }
        }
    }
}
