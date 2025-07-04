using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class WarheadDetonate : CoinPossibility
    {
        private static readonly string _hint = "<color=#b8541a>Wysadziłeś placówkę</color>.";

        public WarheadDetonate() : base("warheadDetonate", 60, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Warhead.Detonate();
        }
    }
}
