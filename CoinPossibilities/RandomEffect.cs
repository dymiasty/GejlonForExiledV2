using Exiled.API.Enums;
using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomEffect : CoinPossibility
    {
        private static readonly string _hint = "Otrzymałeś <color=#fc03a9>losowy efekt</color> na <color=#cafc03>5 sekund</color>.";

        public RandomEffect() : base("randomEffect", 25, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ApplyRandomEffect(EffectCategory.None, 5f);
        }
    }
}
