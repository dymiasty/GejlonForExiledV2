using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class AntiCola : CoinPossibility
    {
        public override string Id => "antiCola";

        public override string Hint => "<color=#871060>D#?t%ł@ś c0^a-$#lę</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.AntiSCP207);
        }
    }
}
