using Exiled.API.Enums;
using Exiled.API.Features;
using System.Collections.Generic;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearAmmo : CoinPossibility
    {
        private static readonly string _hint = "Wyczyszczono ci amunicję.";

        public ClearAmmo() : base("clearAmmo", 30, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player)
        {
            if (player.Ammo.Count == 0)
            {
                return false;
            }

            return true;
        }

        public override void Execute(Player player)
        {
            player.ClearAmmo();
        }
    }
}
