﻿using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class HandsSevered : CoinPossibility
    {
        public override string Id => "handsSevered";

        public override string Hint => "Uciąłeś sobie ręce monetą.";

        public override float HintDuration => 6f;

        public override int Weight => 50;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.SeveredHands);
        }
    }
}
