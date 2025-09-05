using Exiled.API.Features;
using UnityEngine;
using System.Linq;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class PosistionSwap : CoinPossibility
    {
        public override string Id => "positionSwap";

        public override string Hint => "Zamieniłeś się miejscami z losowym graczem.";

        public override int Weight => 40;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player) 
        {
            int alivePlayers = 0;

            foreach (Player playerr in Player.List.ToList())
            {
                if (playerr.IsAlive)
                    alivePlayers++;
            }

            if (alivePlayers <= 1)
                return false;

            return true;
        }

        public override void Execute(Player player)
        {
            Player randomPlayer = Util.RandomAlivePlayer();

            while (randomPlayer == player)
            {
                randomPlayer = Util.RandomAlivePlayer();
            }

            Vector3 randomPlayerPos = new Vector3(randomPlayer.Position.x, randomPlayer.Position.y, randomPlayer.Position.z);

            randomPlayer.Position = player.Position;
            player.Position = randomPlayerPos;

            randomPlayer.ShowHint("Ktoś zamienił się z tobą miejscem.", 6f);
        }
    }
}
