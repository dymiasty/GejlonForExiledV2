using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

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
            Timing.RunCoroutine(Plugin.Instance.RespawnSystemCore.SpawnNTF(), "spawning");

            Timing.RunCoroutine(TimerCoroutine(player));
        }

        private IEnumerator<float> TimerCoroutine(Player coinPlayer)
        {
            Timing.KillCoroutines("respawnTimer");

            foreach (Player player in Plugin.Instance.RespawnTimerCore.Spectators)
                player.CurrentHint.Content = string.Empty;

            int spawnAnimationLength = 18;
            while (spawnAnimationLength > 0)
            {
                yield return Timing.WaitForSeconds(1f);
                string messageToShow = $"{coinPlayer.Nickname} zrespił <color=#0008ff>Nine-Tailed Fox</color> monetą.\n";
                messageToShow += $"Respawn za: <color=#f8ff7a>{spawnAnimationLength}</color> sekund";

                foreach (Player player in Plugin.Instance.RespawnTimerCore.Spectators)
                    player.ShowHint(messageToShow, 1.1f);

                spawnAnimationLength--;
            }
        }
    }
}
