using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class WarheadTrigger : CoinPossibility
    {
        public override string Id => "warheadTrigger";

        public override string Hint => "Przełączyłeś <color=yellow> Warhead </color>.";

        public override float HintDuration => 6f;

        public override int Weight => 27;

        public override PossibilityType possibilityType => PossibilityType.Mid;

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
