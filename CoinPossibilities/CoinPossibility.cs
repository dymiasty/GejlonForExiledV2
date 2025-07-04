using Exiled.API.Features;

namespace GejlonForExiledV2.CoinPossibilities
{
    public abstract class CoinPossibility
    {
        /// <summary>
        /// Text Id of CoinPossibility
        /// </summary>
        public string Id;

        /// <summary>
        /// Hint that will be shown to player
        /// if Execute() method can be executed
        /// </summary>
        public string Hint;

        /// <summary>
        /// Duration of the Hint that will be shown to player
        /// about the effects, when Execute() method executes
        /// </summary>
        public float HintDuration = 6f;

        /// <summary>
        /// Tickets required for Execute() method
        /// to execute, if not met it doesn't
        /// </summary>
        public int RequiredTickets;

        /// <summary>
        /// Variable that tells whether possibility
        /// is good, bad or something in between
        /// for coin flipping player.
        /// </summary>
        public PossibilityType possibilityType;

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
        /// One and only CoinPossibility constructor.
        /// </summary>
        /// <param name="id">Text Id for new CoinPossibility.</param>
        /// <param name="tickets">Required tickets for new CoinPossibility.</param>
        /// <param name="hint">Hint to show to a player for new CoinPossibility.</param>
        /// <param name="type">Type of the new CoinPossibility.</param>
        protected CoinPossibility(string id, int tickets, string hint, PossibilityType type) {
            Id = id;
            RequiredTickets = tickets;
            Hint = hint;
            possibilityType = type;
        }

        /// <summary>
        /// Main method of a CoinPossibility.
        /// It runs if CanExecute() method returns true.
        /// </summary>
        /// <param name="player">Player that flipped the coin.</param>
        public abstract void Execute(Player player);
    }
}
