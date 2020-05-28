using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;

namespace SimpleCountdown.Client
{
    /// <summary>
    /// Client script that shows a countdown to the user. 
    /// </summary>
    public class Script : BaseScript
    {
        #region Fields

        /// <summary>
        /// The ID of the scaleform used to show the Countdown.
        /// </summary>
        private static int scaleform = 0;

        #endregion

        #region Constructor

        public Script()
        {
            LoadScaleform();
        }

        #endregion

        #region Tools

        /// <summary>
        /// Loads and saves the countdown scaleform.
        /// </summary>
        public async Task LoadScaleform()
        {
            // Request the Scaleform
            int s = API.RequestScaleformMovie("COUNTDOWN");
            // Wait until it has been loaded
            while (API.HasScaleformMovieLoaded(s))
            {
                await Delay(0);
            }
            // And save it for later use
            scaleform = s;
        }

        #endregion
    }
}
