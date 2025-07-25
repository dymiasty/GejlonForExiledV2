﻿using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomScpItem : CoinPossibility
    {
        public override string Id => "randomScpItem";

        public override string Hint => "Dostałeś <color=#fc03a9>losowy przedmiot SCP</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomScpItem());
        }
    }
}
