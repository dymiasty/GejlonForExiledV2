﻿using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class FullHeal : CoinPossibility
    {
        public override string Id => "fullHeal";

        public override string Hint => "Zostałeś uleczony <color=green>do pełna</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 85;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Heal(player.MaxHealth, false);
        }
    }
}
