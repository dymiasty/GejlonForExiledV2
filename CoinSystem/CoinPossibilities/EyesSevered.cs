using Exiled.API.Features;
using Exiled.API.Enums;
using GejlonForExiledV2.General;
using MEC;
using System.Collections.Generic;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class EyesSevered : CoinPossibility
    {
        public override string Id => "eyesSevered";

        public override string Hint => "Wyrwałeś sobie oczy ze stresu.";

        public override float HintDuration => 6f;

        public override int Weight => 55;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Timing.RunCoroutine(SevereEyes(player));
        }

        private IEnumerator<float> SevereEyes(Player player)
        {
            player.EnableEffect(EffectType.SeveredEyes);
            yield return Timing.WaitForSeconds(0.1f);
            player.EnableEffect(EffectType.Blinded, 100f);
        }
    }
}
