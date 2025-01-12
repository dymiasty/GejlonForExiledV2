using GejlonForExiledV2.CoinPossibilities;
using System;
using System.Collections.Generic;


namespace GejlonForExiledV2
{
    public class CoinMachine
    {
        /// <summary>
        /// List of all <seealso cref="CoinPossibility">Coin Possibilities</seealso>
        /// that flipping a coin can generate
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
            typeof(LifeSwap) // 42

        };

        /// <returns>
        /// Possibility of numeric id from <paramref name="possibilityNumericId"/>
        /// </returns>
        /// <param name="possibilityNumericId">Numeric Id corresponding
        /// to a possibility in the <see cref="CoinPossibilityTypes"/> list.
        /// </param>
        /// <returns></returns>
        public CoinPossibility GetPossibility(int possibilityNumericId)
        {
            return (CoinPossibility)Activator.CreateInstance(CoinPossibilityTypes[possibilityNumericId]);
        }
    }
}
