using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Ahp40 : CoinPossibility
    {
        public override string Id => "ahp40";

        public override string Hint => "Dostałeś <color=#66fc03>40 AHP</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddAhp(amount: 40f, limit: 120f, decay: 0f, efficacy: 0.7f, sustain: 0, persistant: true);
        }
    }
}
