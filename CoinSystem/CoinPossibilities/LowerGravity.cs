using Exiled.API.Features;
using Exiled.API.Features.Roles;
using GejlonForExiledV2.General;
using UnityEngine;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class LowerGravity : CoinPossibility
    {
        public override string Id => "lowerGravity";

        public override string Hint => "Zmniejszono twoje\nprzyciąganie ziemskie.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            if (player.Role is FpcRole role)
            {
                role.Gravity = new Vector3(role.Gravity.x, role.Gravity.y*0.4f, role.Gravity.z);
            }
        }
    }
}
