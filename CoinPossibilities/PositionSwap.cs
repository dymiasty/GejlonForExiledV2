using Exiled.API.Features;
using Exiled.API.Enums;
using UnityEngine;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class PosistionSwap : CoinPossibility
    {
        private static readonly string _hint = "Zamieniłeś się miejscami z losowym graczem.";

        public PosistionSwap() : base("posSwap", 20, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) {  return true; }

        public override void Execute(Player player)
        {
            Player randomPlayer = Plugin.Instance.RandomAlivePlayer();

            while (randomPlayer == player)
            {
                randomPlayer = Plugin.Instance.RandomAlivePlayer();
            }

            Vector3 randomPlayerPos = new Vector3(randomPlayer.Position.x, randomPlayer.Position.y, randomPlayer.Position.z);

            randomPlayer.Position = player.Position;
            player.Position = randomPlayerPos;

            randomPlayer.ShowHint("Ktoś zamienił się z tobą miejscem.");
        }
    }
}
