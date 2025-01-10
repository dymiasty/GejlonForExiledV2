using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class WarheadTrigger : CoinPossibility
    {
        private static readonly string _hint = "Przełączyłeś <color=yellow>Warhead</color>.";

        public WarheadTrigger() : base("warheadTrigger", 30, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player)
        {
            if (Warhead.IsLocked) return false;
            if (Warhead.IsDetonated) return false;

            return true;
        }

        public override void Execute(Player player)
        {
            if (!Warhead.IsInProgress)
                Warhead.Start();
            else
                Warhead.Stop();
        }
    }
}
