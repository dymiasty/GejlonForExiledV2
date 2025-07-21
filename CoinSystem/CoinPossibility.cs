using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem
{
    public abstract class CoinPossibility
    {
        /// <summary>
        /// Text Id of CoinPossibility
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Hint that will be shown to player
        /// if Execute() method can be executed
        /// </summary>
        public abstract string Hint { get; }

        /// <summary>
        /// Duration of the Hint that will be shown to player
        /// about the effects, when Execute() method executes
        /// </summary>
        public abstract float HintDuration { get; }

        /// <summary>
        /// Weight of the possibility - it dictates the chances
        /// of a possibility to be chosen
        /// </summary>
        public abstract int Weight { get; }

        /// <summary>
        /// Variable that tells whether possibility
        /// is good, bad or something in between
        /// for coin flipping player.
        /// </summary>
        public abstract PossibilityType Type { get; }

        /// <summary>
        /// Method that allows to customize
        /// requirements for a possibility's
        /// Execute() method to be executed
        /// </summary>
        /// <returns>True - if Execute() method should be executed,
        /// False - if Execute() method should NOT be executed.
        /// </returns>
        /// <param name="player">Player that flipped the coin.</param>
        public abstract bool CanExecute(Player player);

        /// <summary>
        /// Main method of a CoinPossibility.
        /// It runs if CanExecute() method returns true.
        /// </summary>
        /// <param name="player">Player that flipped the coin.</param>
        public abstract void Execute(Player player);
    }
}
