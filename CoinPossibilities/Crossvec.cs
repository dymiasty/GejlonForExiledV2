using Exiled.API.Enums;
using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Crossvec : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś pistolet maszynowy <color=#6c807f>Crossvec</color>.";

        public Crossvec() : base("crossvec", 20, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GunCrossvec);
            player.AddAmmo(AmmoType.Nato9, 41);
        }
    }
}
