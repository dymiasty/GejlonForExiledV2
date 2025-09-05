using Exiled.API.Features;
using GejlonForExiledV2.General;
using MEC;
using System.Collections.Generic;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Candy : CoinPossibility
    {
        private const int CANDY_AMOUNT = 2;

        public override string Id => "candy";

        public override string Hint => "Dostałeś <color=#ff96e1>cukierki</color>.";

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Timing.RunCoroutine(Main(player));
        }

        private IEnumerator<float> Main(Player player)
        {
            for (int i = 0; i < CANDY_AMOUNT; i++)
            {
                player.TryAddCandy(Util.GenerateRandomCandy());
                yield return Timing.WaitForSeconds(0.1f);
            }
        }
    }
}
