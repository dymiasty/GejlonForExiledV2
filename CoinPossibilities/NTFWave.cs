using Exiled.API.Features;
using Exiled.API.Enums;
using System.Collections.Generic;
using MEC;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class NTFWave : CoinPossibility
    {
        private static readonly string _hint = "Sforceowałeś spawn <color=#0048ff>NTFu</color>.";

        public NTFWave() : base("NTFWave", 15, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Timing.RunCoroutine(Plugin.Instance.RespawnSystemCore.SpawnNTF());
        }
    }
}
