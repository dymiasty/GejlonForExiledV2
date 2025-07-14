using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class AntiCola : CoinPossibility
    {
        public override string Id => "antiCola";

        public override string Hint => "<color=#871060>D#?t%ł@ś c0^a-$#lę</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 75;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.AntiSCP207);
        }
    }
}
