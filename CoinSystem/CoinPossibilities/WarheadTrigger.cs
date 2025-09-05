using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class WarheadTrigger : CoinPossibility
    {
        public override string Id => "warheadTrigger";

        public override string Hint => "Przełączyłeś <color=yellow> Warhead </color>.";

        public override int Weight => 30;

        public override PossibilityType Type => PossibilityType.Mid;

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
