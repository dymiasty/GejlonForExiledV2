using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Com15 : CoinPossibility
    {
        public override string Id => "com15";

        public override string Hint => "Dostałeś <color=#898e8f>pistolet COM-15</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GunCOM15);
            player.AddAmmo(AmmoType.Nato9, 12);
        }
    }
}
