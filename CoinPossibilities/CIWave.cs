﻿using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class CIWave : CoinPossibility
    {
        private static readonly string _hint = "Sforceowałeś spawn <color=#077516>Rebelii Chaosu</color>.";

        public CIWave() : base("CIWave", 20, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Respawn.ForceWave(PlayerRoles.Faction.FoundationEnemy);
        }
    }
}
