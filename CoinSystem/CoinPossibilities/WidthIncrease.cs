using Exiled.API.Features;
using GejlonForExiledV2.General;
using UnityEngine;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class WidthIncrease : CoinPossibility
    {
        public override string Id => "widthIncrease";

        public override string Hint => "Poszerzyłeś się.";

        public override float HintDuration => 6f;

        public override int Weight => 65;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Scale = new Vector3(player.Scale.x * 1.25f, player.Scale.y, player.Scale.z);
        }
    }
}
