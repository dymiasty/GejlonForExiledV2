using Exiled.API.Features;
using Exiled.API.Enums;
using System.Collections.Generic;
using MEC;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class NTFWave : CoinPossibility
    {
        public override string Id => "NTFWave";

        public override string Hint => "Sforceowałeś spawn <color=#0048ff>NTFu</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType possibilityType => PossibilityType.Mid;

        public override bool CanExecute(Player player)
        {
            if (Plugin.Instance.IsRespawning)
                return false;

            return true;
        }

        public override void Execute(Player player)
        {
            Timing.RunCoroutine(Plugin.Instance.RespawnSystemCore.SpawnNTF());
        }
    }
}
