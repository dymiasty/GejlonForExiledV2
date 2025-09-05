using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomScpItem : CoinPossibility
    {
        public override string Id => "randomScpItem";

        public override string Hint => "Dostałeś <color=#fc03a9>losowy przedmiot SCP</color>.";       

        public override int Weight => 80;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Util.GenerateRandomScpItem());
        }
    }
}
