using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomSpecialWeapon : CoinPossibility
    {
        public override string Id => "randomSpecialWeapon";

        public override string Hint => "Dostałeś <color=#fc03a9>losową broń specjalną</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 85;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomSpecialWeapon());
        }
    }
}
