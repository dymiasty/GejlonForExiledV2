using Exiled.API.Enums;
using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Crossvec : CoinPossibility
    {
        public override string Id => "crossvec";

        public override string Hint => "Dostałeś pistolet maszynowy <color=#6c807f>Crossvec</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 75;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GunCrossvec);
            player.AddAmmo(AmmoType.Nato9, 41);
        }
    }
}
