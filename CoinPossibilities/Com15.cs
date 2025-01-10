using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class Com15 : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#898e8f>pistolet COM-15</color>.";

        public Com15() : base("com15", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GunCOM15);
            player.AddAmmo(AmmoType.Nato9, 12);
        }
    }
}
