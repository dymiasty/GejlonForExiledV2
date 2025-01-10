using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Ahp40 : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#66fc03>40 AHP</color>.";

        public Ahp40() : base("ahp40", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddAhp(amount: 40f, limit: 120f, decay: 0f, efficacy: 0.7f, sustain: 0, persistant: true);
        }
    }
}
