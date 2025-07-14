using Exiled.API.Enums;
using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomEffect : CoinPossibility
    {
        public override string Id => "randomEffect";

        public override string Hint => "Otrzymałeś <color=#fc03a9>losowy efekt</color> na <color=#cafc03>5 sekund</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType possibilityType => PossibilityType.Mid;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ApplyRandomEffect(EffectCategory.None, 5f);
        }
    }
}
