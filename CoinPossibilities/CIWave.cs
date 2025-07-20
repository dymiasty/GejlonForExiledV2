using Exiled.API.Features;
using MEC;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class CIWave : CoinPossibility
    {
        public override string Id => "CIWave";

        public override string Hint => "Sforceowałeś spawn <color=#077516>Rebelii Chaosu</color>.";

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
            Timing.RunCoroutine(Plugin.Instance.RespawnSystemCore.SpawnCI());
        }
    }
}
