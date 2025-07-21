using Exiled.API.Features;
using MEC;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class NTFWave : CoinPossibility
    {
        public override string Id => "NTFWave";

        public override string Hint => "Sforceowałeś spawn <color=#0048ff>NTFu</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 60;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player)
        {
            if (Plugin.Instance.RespawnSystemCore.IsRespawning)
                return false;

            return true;
        }

        public override void Execute(Player player)
        {
            Timing.RunCoroutine(Plugin.Instance.RespawnSystemCore.SpawnNTF());
        }
    }
}
