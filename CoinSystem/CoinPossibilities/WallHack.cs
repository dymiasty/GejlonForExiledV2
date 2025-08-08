using Exiled.API.Features;
using Exiled.API.Enums;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class WallHack : CoinPossibility
    {
        public override string Id => "wallHack";

        public override string Hint => "Dostałeś efekt <color=#800515>SCP-1344</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 60;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.Scp1344);
        }
    }
}
