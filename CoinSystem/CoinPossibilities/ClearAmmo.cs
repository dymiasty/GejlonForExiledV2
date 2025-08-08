using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class ClearAmmo : CoinPossibility
    {
        public override string Id => "clearAmmo";

        public override string Hint => "Wyczyszczono ci amunicję.";

        public override float HintDuration => 6f;

        public override int Weight => 55;

        public override PossibilityType Type => PossibilityType.Negative;

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
