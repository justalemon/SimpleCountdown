using CitizenFX.Core;
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
    }
}
