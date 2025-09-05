using Exiled.API.Enums;
using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomPositiveEffect : CoinPossibility
    {
        public override string Id => "randomPositiveEffect";

        public override string Hint => $"Otrzymałeś <color=#fc03a9>losowy </color><color=#22ff00>pozytywny</color><color=#fc03a9> efekt</color> na <color=#cafc03>{_duration} sekund</color>.";        

        public override int Weight => 75;

        public override PossibilityType Type => PossibilityType.Positive;


        private const float _duration = 10f;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ApplyRandomEffect(EffectCategory.Positive, _duration, true);
        }
    }
}
