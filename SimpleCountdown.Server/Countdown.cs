using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCountdown.Server
{
    /// <summary>
    /// Countdown created by a player.
    /// </summary>
    public class Countdown
    {
        #region Properties

        /// <summary>
        /// The player that owns this countdown.
        /// </summary>
        public Player Owner { get; }
        /// <summary>
        /// The players that leave this countdown.
        /// </summary>
        public List<Player> Participants { get; }
        /// <summary>
        /// The players that have been invited but have not yet accepted.
        /// </summary>
        public List<Player> Invited { get; }

        #endregion

        #region Constructor

        public Countdown(Player player)
        {
            // Save the player and create the lists
            Owner = player;
            Participants = new List<Player>();
            Invited = new List<Player>();

            // And tell the owner what to do
            Owner.TriggerEvent("simplecountdown:notify", $"You have created a countdown! Players can ve invited with /cinvite <Player ID>");
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Invites a player to the countdown.
        /// </summary>
        public void Invite(Player player)
        {
            // Add the player onto the invite list and notify both players
            Invited.Add(player);
            player.TriggerEvent("simplecountdown:notify", $"You have been invited to {Owner.Name}'s countdown. Use /caccept {Owner.Handle} to accept or /cdeny {Owner.Handle} to deny.");
            Owner.TriggerEvent("simplecountdown:notify", $"You have invited {player.Name} to your countdown.");
        }
        /// <summary>
        /// Accepts the countdown of a player.
        /// </summary>
        public void Accept(Player player)
        {
            // If the player is actually invited
            if (Invited.Contains(player))
            {
                // Move him from the invited list to the participants and notify both users
                Invited.Remove(player);
                Participants.Add(player);
                player.TriggerEvent("simplecountdown:notify", $"You accepted {Owner.Name}'s countdown invite. Wait until the countdown is started. You can leave anytime by using the /cleave command.");
                Owner.TriggerEvent("simplecountdown:notify", $"{player.Name} accepted your countdown invite.");
            }
            // If is not
            else
            {
                // Tell him that he has not been invited to the countdown of the other player
                player.TriggerEvent("simplecountdown:notify", $"You have not been invited to {Owner.Name}'s countdown.");
            }
        }
        /// <summary>
        /// Removes a player from the invites.
        /// </summary>
        public void Reject(Player player)
        {
            // If the player is actually invited
            if (Invited.Contains(player))
            {
                // Remove him from the invite list and notify both users
                Invited.Remove(player);
                player.TriggerEvent("simplecountdown:notify", $"You rejected {Owner.Name}'s countdown invite.");
                Owner.TriggerEvent("simplecountdown:notify", $"{player.Name} rejected your countdown invite.");
            }
            // If is not
            else
            {
                // Tell him that he has not been invited to the countdown of the other player
                player.TriggerEvent("simplecountdown:notify", $"You have not been invited to {Owner.Name}'s countdown.");
            }
        }
        /// <summary>
        /// Leaves the countdown after accepting it.
        /// </summary>
        public void Leave(Player player)
        {
            // If the player is actually part of this countdown
            if (Participants.Contains(player))
            {
                // Remove him and notify both users
                Participants.Add(player);
                player.TriggerEvent("simplecountdown:notify", $"You have left {Owner.Name}'s countdown.");
                Owner.TriggerEvent("simplecountdown:notify", $"{player.Name} left your countdown.");
            }
            // If is not
            else
            {
                // Tell him that he has not been invited to the countdown of the other player
                player.TriggerEvent("simplecountdown:notify", $"You have not been invited to {Owner.Name}'s countdown.");
            }
        }

        #endregion
    }
}
