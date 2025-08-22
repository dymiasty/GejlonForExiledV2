using Exiled.API.Features;
using GejlonForExiledV2.General;
using MEC;
using System.Collections.Generic;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class CIWave : CoinPossibility
    {
        public override string Id => "CIWave";

        public override string Hint => "Sforceowałeś spawn <color=#077516>Rebelii Chaosu</color>.";

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
            Timing.KillCoroutines("mainRespawn");
            Timing.RunCoroutine(Plugin.Instance.RespawnSystemCore.SpawnCI(), "spawning");

            Timing.RunCoroutine(TimerCoroutine(player));
        }

        private IEnumerator<float> TimerCoroutine(Player coinPlayer)
        {
            Timing.KillCoroutines("respawnTimer");

            foreach (Player player in Plugin.Instance.RespawnTimerCore.Spectators)
                player.CurrentHint.Content = string.Empty;

            int spawnAnimationLength = 9;
            while (spawnAnimationLength > 0)
            {
                yield return Timing.WaitForSeconds(1f);
                string messageToShow = $"{coinPlayer.Nickname} zrespił <color=#145c20>Rebelię Chaosu</color> monetą.\n";
                messageToShow += $"Respawn za: <color=#f8ff7a>{spawnAnimationLength}</color> sekund";

                foreach (Player player in Plugin.Instance.RespawnTimerCore.Spectators)
                    player.ShowHint(messageToShow, 1.1f);

                spawnAnimationLength--;
            }
        }
    }
}
