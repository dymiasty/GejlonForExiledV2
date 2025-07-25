﻿using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class WarheadDetonate : CoinPossibility
    {
        public override string Id => "warheadDetonate";

        public override string Hint => "<color=#b8541a>Wysadziłeś placówkę</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 9;

        public override PossibilityType Type => PossibilityType.Negative;

        public bool CanDetonate = false;

        public override bool CanExecute(Player player)
        {
            return CanDetonate;
        }

        public override void Execute(Player player)
        {
            Warhead.Detonate();
        }
    }
}
