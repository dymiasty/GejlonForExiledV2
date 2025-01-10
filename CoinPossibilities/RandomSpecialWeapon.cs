using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomSpecialWeapon : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#fc03a9>losową broń specjalną</color>.";

        public RandomSpecialWeapon() : base("randomSpecial", 35, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomSpecialWeapon());
        }
    }
}
