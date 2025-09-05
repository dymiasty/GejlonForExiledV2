using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomMedItem : CoinPossibility
    {
        public override string Id => "randomMedicalItem";

        public override string Hint => "Dostałeś <color=#fc03a9>losowy przedmiot leczący</color>.";        

        public override int Weight => 100;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Util.GenerateRandomMedicalItem());
        }
    }
}
