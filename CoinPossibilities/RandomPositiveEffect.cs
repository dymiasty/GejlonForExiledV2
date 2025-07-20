using Exiled.API.Enums;
using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomPositiveEffect : CoinPossibility
    {
        public override string Id => "randomPositiveEffect";

        public override string Hint => "Otrzymałeś <color=#fc03a9>losowy </color><color=lime>pozytywny</color><color=#fc03a9> efekt</color> na <color=#cafc03>5 sekund</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ApplyRandomEffect(EffectCategory.Positive, 5f);
        }
    }
}
