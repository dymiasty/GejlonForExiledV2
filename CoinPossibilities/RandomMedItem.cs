using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomMedItem : CoinPossibility
    {
        public override string Id => "randomMedicalItem";

        public override string Hint => "Dostałeś <color=#fc03a9>losowy przedmiot leczący</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 110;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomMedicalItem());
        }
    }
}
