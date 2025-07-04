using GejlonForExiledV2.CoinPossibilities;
using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;


namespace GejlonForExiledV2
{
    public class CoinMachine
    {
        /// <summary>
        /// List of all <seealso cref="CoinPossibility">Coin Possibilities</seealso>
        /// that flipping a coin can generate.
        /// </summary>
        public List<Type> CoinPossibilityTypes = new List<Type>
        {
            typeof(Ahp40), // 0
            typeof(AntiCola), // 1
            typeof(Blackout), // 2
            typeof(Candy), // 3
            typeof(CIWave), // 4
            typeof(ClearAmmo), // 5
            typeof(ClearInventory), // 6
            typeof(ClearKeycards), // 7
            typeof(Com15), // 8
            typeof(Crossvec), // 9
            typeof(DoorSystemRestart), // 10
            typeof(EscapeTeleport), // 11
            typeof(Explode), // 12
            typeof(EyesSevered), // 13
            typeof(Flashbang), // 14
            typeof(Flashlight), // 15
            typeof(FRMG0), // 16
            typeof(FullHeal), // 17
            typeof(Ghost), // 18
            typeof(Grenade), // 19
            typeof(HandsSevered), // 20
            typeof(HealFor50), // 21
            typeof(NTFWave), // 22
            typeof(O5Keycard), // 23
            typeof(OneHp), // 24
            typeof(PocketDimension), // 25
            typeof(QuickDecontamination), // 26
            typeof(Radio), // 27
            typeof(RandomEffect), // 28
            typeof(RandomKeycard), // 29
            typeof(RandomPlayerExplode), // 30
            typeof(RandomScpItem), // 31
            typeof(RandomScpTeleport), // 32
            typeof(RandomSpecialWeapon), // 33
            typeof(RandomTeleport), // 34
            typeof(WarheadDetonate), // 35
            typeof(WarheadTrigger), // 36
            typeof(WeaponExchange), // 37
            typeof(RandomMedItem), // 38
            typeof(InventorySwap), // 39
            typeof(RandomRole), // 40
            typeof(PosistionSwap), // 41
            typeof(LifeSwap), // 42
            typeof(UpgradeKeycards), // 43
            typeof(DowngradeKeycards), // 44
        };

        /// <returns>
        /// Possibility of numeric id from <paramref name="possibilityNumericId"/>.
        /// </returns>
        /// <param name="possibilityNumericId">Numeric Id corresponding
        /// to a possibility in the <see cref="CoinPossibilityTypes"/> list.
        /// </param>
        /// <returns></returns>
        public CoinPossibility GetPossibility(int possibilityNumericId)
        {
            return (CoinPossibility)Activator.CreateInstance(CoinPossibilityTypes[possibilityNumericId]);
        }

        /// <summary>
        /// A debug command made for testing
        /// coin flipping possibilities.
        /// 
        /// The only parameter it takes is numeric id corresponding
        /// to a possibility in the <see cref="CoinPossibilityTypes"/> list.
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
                int tickets = 100;
                bool canExecute;
                int wynik = Int32.Parse(arguments.ElementAt(0));
                CoinPossibility possibility = Plugin.Instance.CoinMachine.GetPossibility(wynik);
                Log.Info(player.Nickname + " rzucił monetą i trafił " + possibility.Id);

                canExecute = possibility.CanExecute(player);

                if (tickets < possibility.RequiredTickets)
                    canExecute = false;

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
