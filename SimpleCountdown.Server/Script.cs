using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace SimpleCountdown.Server
{
    /// <summary>
    /// Server Script that handles the countdown.
    /// </summary>
    public class Script : BaseScript
    {
        #region Private Fields

        /// <summary>
        /// Players and their countdowns created or joined.
        /// </summary>
        private readonly Dictionary<Player, Countdown> countdowns = new Dictionary<Player, Countdown>();

        #endregion

        #region Commands

        /// <summary>
        /// Command that creates a countdown.
        /// </summary>
        [Command("ccreate")]
        public void CommandCreate(int source, List<object> param, string raw)
        {
            // If the user is not allowed to create a countdown, ignore it silently
            if (!API.IsPlayerAceAllowed(source.ToString(), "simplecountdown.create"))
            {
                return;
            }

            // Make a player object
            Player player = Players[source];

            // If the player has a countdown already, notify him
            if (countdowns.ContainsKey(player))
            {
                player.TriggerEvent("simplecountdown:notify", $"You can't create a countdown when you are already in one.");
                return;
            }

            // Otherwise, create a new countdown for the player
            countdowns[player] = new Countdown(player);
        }

        #endregion
    }
}
